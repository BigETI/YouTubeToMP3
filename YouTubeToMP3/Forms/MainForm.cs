using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.SharpClipboardNS;

namespace YouTubeToMP3.Forms
{
    public partial class MainForm : Form
    {
        private static readonly string configurationFilePath = "./config.json";

        private static readonly string idFieldName = "id";

        private static readonly string destinationPathFieldName = "destinationPath";

        private static readonly string isEnabledFieldName = "isEnabled";

        private static readonly string titleFieldName = "title";

        private static readonly string statusFieldName = "status";

        private static readonly string progressFieldName = "progress";

        private static readonly string sizeFieldName = "size";

        private static readonly string speedFieldName = "speed";

        private static readonly string etaFieldName = "eta";

        private static readonly string timeFieldName = "time";

        private static readonly string defaultTitleName = "YouTube to MP3";

        private static readonly string startDownloadingText = "Start downloading";

        private static readonly string terminateProcessesText = "Terminate processes";

        private readonly SharpClipboard clipboard = new SharpClipboard();

        private readonly List<(Task<string> Task, HttpClient HTTPClient)> internetStringTasks = new List<(Task<string> Task, HttpClient HTTPClient)>();

        private PreferencesForm preferencesForm;

        private AboutForm aboutForm;

        public bool IsAnyDownloadActive { get; private set; }

        public ISettings Settings { get; } = new Settings(configurationFilePath);

        public IDownloadsManager DownloadsManager { get; }

        public MainForm()
        {
            DownloadsManager = new DownloadsManager(Settings.MaximalConcurrentlyRunningProcessCount);
            DownloadsManager.OnYouTubeDownloadStateAdded +=
                (youTubeDownloadState) =>
                {
                    startupTableLayoutPanel.Visible = false;
                    DataRow data_row = urlDataTable.NewRow();
                    UpdateYouTubeDownloadStateDataRow(youTubeDownloadState, data_row);
                    urlDataTable.Rows.Add(data_row);
                    UpdateButtons(true);
                    if (Settings.IsFetchingVideoInformationAutomatically)
                    {
                        youTubeDownloadState.EnqueueFetchingInformation();
                    }
                };
            DownloadsManager.OnYouTubeDownloadStateUpdated +=
                (youTubeDownloadState) =>
                {
                    if (TryGettingYouTubeDownloadStateDataRow(youTubeDownloadState.YouTubeURL, out DataRow data_row))
                    {
                        UpdateYouTubeDownloadStateDataRow(youTubeDownloadState, data_row);
                    }
                    UpdateButtons(true);
                };
            DownloadsManager.OnYouTubeDownloadStateRemoved +=
                (youTubeDownloadState) =>
                {
                    if (TryGettingYouTubeDownloadStateDataRow(youTubeDownloadState.YouTubeURL, out DataRow data_row))
                    {
                        urlDataTable.Rows.Remove(data_row);
                    }
                    UpdateButtons(true);
                };
            DownloadsManager.OnFetchingPlaylistInformationStarted += (_) => UpdateTitleText();
            DownloadsManager.OnFetchingPlaylistInformationFinished += (_) => UpdateTitleText();
            Settings.OnAddingYouTubeURLsAutomaticallyFromClipboardStateChanged +=
                (_, newAddingYouTubeURLsAutomaticallyFromClipboardState) =>
                    automaticallyAddURLsFromClipboardToolStripMenuItem.Checked = newAddingYouTubeURLsAutomaticallyFromClipboardState;
            Settings.OnFetchingVideoInformationAutomaticallyStateChanged +=
                (_, newFetchingVideoInformationAutomaticallyState) =>
                    automaticallyFetchVideoInformationToolStripMenuItem.Checked = newFetchingVideoInformationAutomaticallyState;
            Settings.OnMaximalConcurrentlyRunningProcessCountLimitStateChanged += (_, __) => UpdateMaximalConcurrentlyRunningProcessCount();
            Settings.OnMaximalConcurrentlyRunningProcessCountChanged += (_, __) => UpdateMaximalConcurrentlyRunningProcessCount();
            InitializeComponent();
            automaticallyAddURLsFromClipboardToolStripMenuItem.Checked = Settings.IsAddingYouTubeURLsAutomaticallyFromClipboard;
            automaticallyFetchVideoInformationToolStripMenuItem.Checked = Settings.IsFetchingVideoInformationAutomatically;
        }

        private static void UpdateYouTubeDownloadStateDataRow(IYouTubeDownloadState youTubeDownloadState, DataRow dataRow)
        {
            dataRow.SetField(idFieldName, youTubeDownloadState.YouTubeURL.VideoID);
            dataRow.SetField(destinationPathFieldName, youTubeDownloadState.DestinationFilePath);
            dataRow.SetField(isEnabledFieldName, youTubeDownloadState.IsDownloadEnabled);
            dataRow.SetField(titleFieldName, youTubeDownloadState.Title);
            dataRow.SetField
            (
                statusFieldName,
                NamedYouTubeDownloadStatus.GetYouTubeDownloadStatusName(youTubeDownloadState.YouTubeDownloadStatus, youTubeDownloadState.LastExitCode)
            );
            dataRow.SetField(progressFieldName, youTubeDownloadState.DownloadProgressString);
            dataRow.SetField(sizeFieldName, youTubeDownloadState.FileSizeString);
            dataRow.SetField(speedFieldName, youTubeDownloadState.DownloadSpeedString);
            dataRow.SetField(etaFieldName, youTubeDownloadState.ETAString);
            dataRow.SetField(timeFieldName, youTubeDownloadState.ElapsedTimeString);
        }

        private static string EscapeCharacters(string characters)
        {
            StringBuilder sb = new StringBuilder(characters.Length);
            foreach (char character in characters)
            {
                switch (character)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(character).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(character);
                        break;
                }
            }
            return sb.ToString();
        }

        private static void EnsureDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private static void BrowseAtYouTube() => Process.Start("https://www.youtube.com/");

        private void UpdateTitleText()
        {
            if ((DownloadsManager.IsFetchingPlaylistInformation) || (internetStringTasks.Count > 0))
            {
                Text = $"{defaultTitleName} - Fetching URLs...";
            }
            else
            {
                Text = defaultTitleName;
            }
        }

        private void UpdateMaximalConcurrentlyRunningProcessCount()
        {
            DownloadsManager.ProcessQueue.MaximalConcurrentlyRunningProcessCount =
                Settings.IsMaximalConcurrentlyRunningProcessCountLimitDisabled ?
                    uint.MaxValue :
                    Settings.MaximalConcurrentlyRunningProcessCount;
        }

        private bool TryGettingYouTubeDownloadStateDataRow(YouTubeURL youTubeURL, out DataRow dataRow)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("Specified YOuTube URL needs to contain a video ID.", nameof(youTubeURL));
            }
            DataRow[] data_rows = urlDataTable.Select($"`id`='{EscapeCharacters(youTubeURL.VideoID)}'");
            bool ret = data_rows.Length > 0;
            dataRow = ret ? data_rows[0] : null;
            return ret;
        }

        private void ShowLoadURLsFromFileDialog()
        {
            DialogResult dialog_result = urlsOpenFileDialog.ShowDialog();
            DialogResult = DialogResult.None;
            if ((dialog_result == DialogResult.OK) || (dialog_result == DialogResult.Yes))
            {
                foreach (string urls_file_path in urlsOpenFileDialog.FileNames)
                {
                    try
                    {
                        if (File.Exists(urls_file_path))
                        {
                            using (FileStream file_stream = File.OpenRead(urls_file_path))
                            {
                                using (StreamReader stream_reader = new StreamReader(file_stream, true))
                                {
                                    DownloadsManager.AddYouTubeURLsFromString(stream_reader.ReadToEnd());
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }
        }

        private void ShowLoadURLsFromAnInternetResourceDialog()
        {
            using (LoadURLsFromAnInternetResourceForm load_urls_from_an_internet_resource_form = new LoadURLsFromAnInternetResourceForm())
            {
                DialogResult dialog_result = load_urls_from_an_internet_resource_form.ShowDialog();
                DialogResult = DialogResult.None;
                if (dialog_result == DialogResult.OK)
                {
                    HttpClient http_client = new HttpClient();
                    internetStringTasks.Add((http_client.GetStringAsync(load_urls_from_an_internet_resource_form.URI), http_client));
                    UpdateTitleText();
                }
            }
        }

        private void UpdateDownloadActivityFlag()
        {
            IsAnyDownloadActive = false;
            foreach (YouTubeDownloadStateEvents you_tube_download_state_events in DownloadsManager.YouTubeDownloadStateEvents.Values)
            {
                if (you_tube_download_state_events.YouTubeDownloadState.IsDownloading)
                {
                    IsAnyDownloadActive = true;
                    break;
                }
            }
        }

        private void UpdateButtons(bool isUpdatingDownloadActivityFlag)
        {
            if (isUpdatingDownloadActivityFlag)
            {
                UpdateDownloadActivityFlag();
            }
            UpdateStartDownloadingButtonState(false);
            UpdateEntrySelectionButtons();
            UpdateRemoveHighlightedEntriesButton(false);
        }

        private void UpdateStartDownloadingButtonState(bool isUpdatingDownloadActivityFlag)
        {
            if (isUpdatingDownloadActivityFlag)
            {
                UpdateDownloadActivityFlag();
            }
            bool is_enabled = IsAnyDownloadActive;
            startDownloadingButton.Text = is_enabled ? terminateProcessesText : startDownloadingText;
            if (!is_enabled)
            {
                foreach (YouTubeDownloadStateEvents you_tube_download_state_events in DownloadsManager.YouTubeDownloadStateEvents.Values)
                {
                    if (you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled)
                    {
                        is_enabled = true;
                        break;
                    }
                }
            }
            startDownloadingButton.Enabled = is_enabled;
        }

        private void UpdateEntrySelectionButtons()
        {
            bool is_enabled = DownloadsManager.YouTubeDownloadStateEvents.Count > 0;
            enableEverythingToolStripMenuItem.Enabled = is_enabled;
            disableEverythingToolStripMenuItem.Enabled = is_enabled;
        }

        private void UpdateRemoveHighlightedEntriesButton(bool isUpdatingDownloadActivityFlag)
        {
            if (isUpdatingDownloadActivityFlag)
            {
                UpdateDownloadActivityFlag();
            }
            removeHighlightedEntriesToolStripMenuItem.Enabled = !IsAnyDownloadActive && (urlsDataGridView.SelectedRows.Count > 0);
        }

        private void MainFormShownEvent(object sender, EventArgs e) =>
            clipboard.ClipboardChanged += ClipboardClipboardChangedEvent;

        private void MainFormFormClosedEvent(object sender, FormClosedEventArgs e)
        {
            clipboard.ClipboardChanged -= ClipboardClipboardChangedEvent;
            Settings.SaveConfigurationFile(configurationFilePath);
        }

        private void LoadURLsFromFilesToolStripMenuItemClickEvent(object sender, EventArgs e) => ShowLoadURLsFromFileDialog();

        private void LoadURLsFromAnInternetResourceToolStripMenuItemClickEvent(object sender, EventArgs e) => ShowLoadURLsFromAnInternetResourceDialog();

        private void SaveURLsAsToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            DialogResult dialog_result = urlsSaveFileDialog.ShowDialog();
            DialogResult = DialogResult.None;
            if ((dialog_result == DialogResult.OK) || (dialog_result == DialogResult.Yes))
            {
                string urls_file_path = urlsSaveFileDialog.FileName;
                try
                {
                    using (FileStream file_stream = File.Open(urls_file_path, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter file_stream_writer = new StreamWriter(file_stream))
                        {
                            foreach (YouTubeDownloadStateEvents you_tube_download_sate_events in DownloadsManager.YouTubeDownloadStateEvents.Values)
                            {
                                file_stream_writer.WriteLine(you_tube_download_sate_events.YouTubeDownloadState.YouTubeURL.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }

        private void DownloadRemainingSelectedEntriesToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            DownloadsManager.EnqueueMP3Downloads(Settings.MP3DownloadsDirectoryPath, true);

        private void DownloadOnlyHighlightedAndEnabledEntriesToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            foreach (DataGridViewRow data_grid_view_row in urlsDataGridView.SelectedRows)
            {
                if
                (
                    (data_grid_view_row.Cells[0].Value is string video_id) &&
                    DownloadsManager.YouTubeDownloadStateEvents.TryGetValue(video_id, out YouTubeDownloadStateEvents you_tube_download_state_events)
                )
                {
                    if (you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled)
                    {
                        you_tube_download_state_events.YouTubeDownloadState.EnqueueMP3Download(Settings.MP3DownloadsDirectoryPath);
                    }
                }
            }
        }

        private void DownloadEverythingEnabledToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            DownloadsManager.EnqueueMP3Downloads(Settings.MP3DownloadsDirectoryPath, false);

        private void ExitToolStripMenuItemClickEvent(object sender, EventArgs e) => Application.Exit();

        private void EnableEverythingToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            foreach (YouTubeDownloadStateEvents you_tube_download_state_events in DownloadsManager.YouTubeDownloadStateEvents.Values)
            {
                you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled = true;
            }
        }

        private void DisableEverythingToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            foreach (YouTubeDownloadStateEvents you_tube_download_state_events in DownloadsManager.YouTubeDownloadStateEvents.Values)
            {
                you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled = false;
            }
        }

        private void PasteURLsFromClipboardToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            DownloadsManager.AddYouTubeURLsFromString(Clipboard.GetText());

        private void RemoveHighlightedEntriesToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            if (!IsAnyDownloadActive && (urlsDataGridView.SelectedRows.Count > 0))
            {
                List<YouTubeURL> you_tube_urls = new List<YouTubeURL>();
                foreach (DataGridViewRow selected_data_grid_view_row in urlsDataGridView.SelectedRows)
                {
                    if
                    (
                        (selected_data_grid_view_row.Cells[0].Value is string video_id) &&
                        YouTubeURL.TryCreatingYouTubeURLFromVideoID(video_id, out YouTubeURL you_tube_url)
                    )
                    {
                        you_tube_urls.Add(you_tube_url);
                    }
                }
                foreach (YouTubeURL you_tube_url in you_tube_urls)
                {
                    DownloadsManager.RemoveYouTubeURL(you_tube_url);
                }
                you_tube_urls.Clear();
                UpdateButtons(true);
            }
        }

        private void FetchInformationToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selected_data_grid_view_row in urlsDataGridView.SelectedRows)
            {
                if
                (
                    (selected_data_grid_view_row.Cells[0].Value is string video_id) &&
                    DownloadsManager.YouTubeDownloadStateEvents.TryGetValue(video_id, out YouTubeDownloadStateEvents you_tube_download_state_events)
                )
                {
                    if (!you_tube_download_state_events.YouTubeDownloadState.IsDownloading)
                    {
                        you_tube_download_state_events.YouTubeDownloadState.EnqueueFetchingInformation();
                    }
                }
            }
        }

        private void PreferencesToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            if (preferencesForm == null)
            {
                preferencesForm = new PreferencesForm(Settings);
            }
            try
            {
                if (!preferencesForm.Visible)
                {
                    preferencesForm.Show();
                }
            }
            catch
            {
                preferencesForm = new PreferencesForm(Settings);
                preferencesForm.Show();
            }
        }

        private void ShowInExplorerToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            string mp3_downloads_directory_path = Path.GetFullPath(Settings.MP3DownloadsDirectoryPath);
            EnsureDirectory(mp3_downloads_directory_path);
            Process.Start("explorer", mp3_downloads_directory_path);
        }

        private void BrowseAtYouTubeToolStripMenuItemClickEvent(object sender, EventArgs e) => BrowseAtYouTube();

        private void AutomaticallyAddURLsFromClipboardToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            Settings.IsAddingYouTubeURLsAutomaticallyFromClipboard = !Settings.IsAddingYouTubeURLsAutomaticallyFromClipboard;

        private void AutomaticallyFetchVideoInformationToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            Settings.IsFetchingVideoInformationAutomatically = !Settings.IsFetchingVideoInformationAutomatically;

        private void AboutToolStripMenuItemClickEvent(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
            }
            try
            {
                if (!aboutForm.Visible)
                {
                    aboutForm.Show();
                }
            }
            catch
            {
                aboutForm = new AboutForm();
                aboutForm.Show();
            }
        }

        private void DonateAtKofiToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            Process.Start("https://ko-fi.com/bigeti");

        private void GitHubRepositoryToolStripMenuItemClickEvent(object sender, EventArgs e) =>
            Process.Start("https://github.com/BigETI/YouTubeToMP3");

        private void BrowseAtYouTubePictureBoxClickEvent(object sender, EventArgs e) => BrowseAtYouTube();

        private void LoadURLsFromFilePictureBoxClickEvent(object sender, EventArgs e) => ShowLoadURLsFromFileDialog();

        private void LoadURLsFromAnInternetResourcePictureBoxClickEvent(object sender, EventArgs e) => ShowLoadURLsFromAnInternetResourceDialog();

        private void URLsDataGridViewCellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            bool is_updating_download_activity_flag = true;
            if (!IsAnyDownloadActive && (e.ColumnIndex == 2) && (e.RowIndex >= 0) && (e.RowIndex < urlDataTable.Rows.Count))
            {
                if
                (
                    (urlsDataGridView.Rows[e.RowIndex].Cells[0].Value is string video_id) &&
                    DownloadsManager.YouTubeDownloadStateEvents.TryGetValue(video_id, out YouTubeDownloadStateEvents you_tube_download_state_events)
                )
                {
                    you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled = !you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled;
                    UpdateStartDownloadingButtonState(true);
                    is_updating_download_activity_flag = false;
                }
            }
            UpdateRemoveHighlightedEntriesButton(is_updating_download_activity_flag);
        }

        private void URLsDataGridViewCellDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.RowIndex < urlsDataGridView.Rows.Count))
            {
                string url = urlsDataGridView.Rows[e.RowIndex].Cells[1].Value as string;
                if (!string.IsNullOrWhiteSpace(url))
                {
                    Process.Start(url);
                }
            }
        }

        private void StartDownloadingButtonClickEvent(object sender, EventArgs e)
        {
            if (IsAnyDownloadActive)
            {
                DownloadsManager.TerminateAndDequeueAllMP3DownloadProcesses();
            }
            else
            {
                DownloadsManager.EnqueueMP3Downloads(Settings.MP3DownloadsDirectoryPath, true);
            }
        }

        private void BrowseAtYouTubeButtonClickEvent(object sender, EventArgs e) => BrowseAtYouTube();

        private void TimerTickEvent(object sender, EventArgs e)
        {
            DownloadsManager.ProcessEvents();
            for (int internet_string_task_index = internetStringTasks.Count - 1; internet_string_task_index >= 0; internet_string_task_index--)
            {
                (Task<string> internet_string_task, HttpClient http_client) = internetStringTasks[internet_string_task_index];
                TaskStatus task_status = internet_string_task.Status;
                if (task_status == TaskStatus.RanToCompletion)
                {
                    DownloadsManager.AddYouTubeURLsFromString(internet_string_task.Result);
                    internetStringTasks.RemoveAt(internet_string_task_index);
                    http_client.Dispose();
                    UpdateTitleText();
                }
                else if ((task_status == TaskStatus.Canceled) || (task_status == TaskStatus.Faulted))
                {
                    internetStringTasks.RemoveAt(internet_string_task_index);
                    http_client.Dispose();
                    UpdateTitleText();
                }
            }
        }

        private void ClipboardClipboardChangedEvent(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (!IsAnyDownloadActive && Settings.IsAddingYouTubeURLsAutomaticallyFromClipboard)
            {
                DownloadsManager.AddYouTubeURLsFromString(Clipboard.GetText());
            }
        }
    }
}
