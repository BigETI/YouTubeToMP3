using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using YouTubeToMP3.Data;

namespace YouTubeToMP3
{
    internal sealed class YouTubeDownloadState : IYouTubeDownloadState
    {
        private static readonly string notAvailableString = "N/A";

        private static readonly Regex downloadOutputLineRegex =
            new Regex
            (
                @"\[download\]\W+(?:Destination:\W+(?<destinationFileName>.*)|(?<downloadProgress>[0-9]+\.?[0-9]*%)\W+of\W+(?<fileSize>[0-9]+\.?[0-9A-Za-z]+)\W+(?:at\W+(?<downloadSpeed>[./0-9A-Za-z]+)\W+ETA\W+(?<eta>[:0-9]+)|in\W+(?<elapsedTime>[:0-9]+)))",
                RegexOptions.Compiled
            );

        private static readonly Regex ffmpegOutputLineRegex = new Regex(@"\[ffmpeg\]\W+Destination:\W+(?<destinationFileName>.*)", RegexOptions.Compiled);

        private static readonly DataContractJsonSerializer dataContractJSONSerializer = new DataContractJsonSerializer(typeof(YouTubeVideoInformationData));

        private bool isDownloadEnabled = true;

        private volatile bool isDownloading;

        private volatile EYouTubeDownloadStatus youTubeDownloadStatus = EYouTubeDownloadStatus.Added;

        private volatile string title;

        private volatile string channelName = string.Empty;

        private volatile string destinationFilePath = string.Empty;

        private volatile string downloadProgressString = notAvailableString;

        private volatile string fileSizeString = notAvailableString;

        private volatile string downloadSpeedString = notAvailableString;

        private volatile string etaString = "N/A";

        private volatile string elapsedTimeString = "N/A";

        private volatile int lastExitCode = -1;

        private Process lastProcess;

        public bool IsDownloadEnabled
        {
            get => isDownloadEnabled;
            set
            {
                if (isDownloadEnabled != value)
                {
                    bool was_download_enabled = isDownloadEnabled;
                    isDownloadEnabled = value;
                    OnDownloadEnabledStateChanged?.Invoke(was_download_enabled, isDownloadEnabled);
                }
            }
        }

        public bool IsDownloading
        {
            get => isDownloading;
            set
            {
                bool was_downloading = isDownloading;
                if (was_downloading != value)
                {
                    isDownloading = value;
                    OnDownloadStateChanged?.Invoke(was_downloading, value);
                }
            }
        }

        public EYouTubeDownloadStatus YouTubeDownloadStatus
        {
            get => youTubeDownloadStatus;
            private set
            {
                EYouTubeDownloadStatus old_you_tube_download_status = youTubeDownloadStatus;
                if (old_you_tube_download_status != value)
                {
                    youTubeDownloadStatus = value;
                    OnYouTubeDownloadStatusChanged?.Invoke(old_you_tube_download_status, value);
                }
            }
        }

        public string Title
        {
            get => title;
            private set
            {
                string old_title = title;
                if (old_title != value)
                {
                    title = value;
                    OnTitleChanged?.Invoke(old_title, value);
                }
            }
        }

        public string ChannelName
        {
            get => channelName;
            private set
            {
                string old_channel_name = channelName;
                if (old_channel_name != value)
                {
                    channelName = value;
                    OnChannelNameChanged?.Invoke(old_channel_name, value);
                }
            }
        }

        public string DestinationFilePath
        {
            get => destinationFilePath;
            private set
            {
                string old_destination_path = destinationFilePath;
                if (old_destination_path != value)
                {
                    destinationFilePath = value;
                    OnDestinationFilePathChanged?.Invoke(old_destination_path, value);
                }
            }
        }

        public string DownloadProgressString
        {
            get => downloadProgressString;
            private set
            {
                string old_progress_string = downloadProgressString;
                if (old_progress_string != value)
                {
                    downloadProgressString = value;
                    OnDownloadProgressStringChanged?.Invoke(old_progress_string, value);
                }
            }
        }

        public string FileSizeString
        {
            get => fileSizeString;
            private set
            {
                string old_file_size_string_size = fileSizeString;
                if (old_file_size_string_size != value)
                {
                    fileSizeString = value;
                    OnFileSizeStringChanged?.Invoke(old_file_size_string_size, value);
                }
            }
        }

        public string DownloadSpeedString
        {
            get => downloadSpeedString;
            private set
            {
                string old_download_speed_string_size = downloadSpeedString;
                if (old_download_speed_string_size != value)
                {
                    downloadSpeedString = value;
                    OnDownloadSpeedStringChanged?.Invoke(old_download_speed_string_size, value);
                }
            }
        }

        public string ETAString
        {
            get => etaString;
            private set
            {
                string old_eta_string_size = etaString;
                if (old_eta_string_size != value)
                {
                    etaString = value;
                    OnETAStringChanged?.Invoke(old_eta_string_size, value);
                }
            }
        }

        public string ElapsedTimeString
        {
            get => elapsedTimeString;
            private set
            {
                string old_elapsed_time_string_size = elapsedTimeString;
                if (old_elapsed_time_string_size != value)
                {
                    elapsedTimeString = value;
                    OnElapsedTimeStringChanged?.Invoke(old_elapsed_time_string_size, value);
                }
            }
        }

        public int LastExitCode => lastExitCode;

        public YouTubeURL YouTubeURL { get; }

        public IDownloadsManager DownloadsManager { get; }

        public event DownloadEnabledStateChangedDelegate OnDownloadEnabledStateChanged;

        public event DownloadStateChangedDelegate OnDownloadStateChanged;

        public event YouTubeDownloadStatusChangedDelegate OnYouTubeDownloadStatusChanged;

        public event TitleChangedDelegate OnTitleChanged;

        public event ChannelNameChangedDelegate OnChannelNameChanged;

        public event DestinationFilePathChangedDelegate OnDestinationFilePathChanged;

        public event DownloadProgressStringChangedDelegate OnDownloadProgressStringChanged;

        public event FileSizeStringChangedDelegate OnFileSizeStringChanged;

        public event DownloadSpeedStringChangedDelegate OnDownloadSpeedStringChanged;

        public event ETAStringChangedDelegate OnETAStringChanged;

        public event ElapsedTimeStringChangedDelegate OnElapsedTimeStringChanged;

        public YouTubeDownloadState(YouTubeURL youTubeURL, IDownloadsManager downloadManager)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("Specified YouTube URL needs to contain a video ID.");
            }
            YouTubeURL = youTubeURL;
            DownloadsManager = downloadManager ?? throw new ArgumentNullException(nameof(downloadManager));
            title = youTubeURL.ToString();
        }

        private void UpateInformationAfterProcessExit(Process process, bool isMarkingAsFinished)
        {
            int exit_code = process.ExitCode;
            lastExitCode = exit_code;
            YouTubeDownloadStatus =
                (exit_code == 0) ? (isMarkingAsFinished ? EYouTubeDownloadStatus.Finished : EYouTubeDownloadStatus.Added) : EYouTubeDownloadStatus.Error;
            lastProcess = null;
            IsDownloading = false;
        }

        public bool EnqueueFetchingInformation()
        {
            EYouTubeDownloadStatus you_tube_download_status = youTubeDownloadStatus;
            bool ret =
                (you_tube_download_status == EYouTubeDownloadStatus.Added) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Finished) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Terminated) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Error);
            if (ret)
            {
                Process process = DownloadsManager.YTDLP.CreateNewFetchVideoOrPlaylistInformationProcess(YouTubeURL, false);
                process.OutputDataReceived +=
                    (_, e) =>
                    {
                        string line = e.Data;
                        if (line != null)
                        {
                            using (MemoryStream memory_stream = new MemoryStream())
                            {
                                using (StreamWriter stream_writer = new StreamWriter(memory_stream, new UTF8Encoding(false), 1024, true))
                                {
                                    stream_writer.Write(line);
                                    stream_writer.Flush();
                                }
                                memory_stream.Seek(0L, SeekOrigin.Begin);
                                if (dataContractJSONSerializer.ReadObject(memory_stream) is YouTubeVideoInformationData you_tube_video_information_data)
                                {
                                    if (!string.IsNullOrWhiteSpace(you_tube_video_information_data.Title))
                                    {
                                        Title = you_tube_video_information_data.Title;
                                    }
                                    if (!string.IsNullOrWhiteSpace(you_tube_video_information_data.ChannelName))
                                    {
                                        ChannelName = you_tube_video_information_data.ChannelName;
                                    }
                                }
                            }
                        }
                    };
                process.Exited += (_, __) => UpateInformationAfterProcessExit(process, false);
                YouTubeDownloadStatus = EYouTubeDownloadStatus.FetchingInformation;
                lastProcess = process;
                IsDownloading = false;
                DownloadsManager.ProcessQueue.EnqueueProcess(process);
            }
            return ret;
        }

        public bool EnqueueMP3Download(string outputDirectory)
        {
            if (string.IsNullOrWhiteSpace(outputDirectory))
            {
                throw new ArgumentNullException(nameof(outputDirectory));
            }
            EYouTubeDownloadStatus you_tube_download_status = youTubeDownloadStatus;
            bool ret =
                (you_tube_download_status == EYouTubeDownloadStatus.Added) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Finished) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Terminated) ||
                (you_tube_download_status == EYouTubeDownloadStatus.Error);
            string output_directory = outputDirectory;
            if (ret)
            {
                Process process = DownloadsManager.YTDLP.CreateNewDownloadVideoToMP3Process(YouTubeURL, output_directory, false);
                process.OutputDataReceived +=
                    (_, e) =>
                    {
                        string line = e.Data;
                        if (line != null)
                        {
                            Match download_output_line_match = downloadOutputLineRegex.Match(line);
                            if (download_output_line_match.Success)
                            {
                                Group destination_file_name_group = download_output_line_match.Groups["destinationFileName"];
                                Group download_progress_group = download_output_line_match.Groups["downloadProgress"];
                                Group file_size_group = download_output_line_match.Groups["fileSize"];
                                Group download_speed_group = download_output_line_match.Groups["downloadSpeed"];
                                Group eta_group = download_output_line_match.Groups["eta"];
                                Group elapsed_time_group = download_output_line_match.Groups["elapsedTime"];
                                if (destination_file_name_group.Success)
                                {
                                    string destination_file_name = destination_file_name_group.Value;
                                    if (!destination_file_name.EndsWith(".mp3"))
                                    {
                                        destination_file_name = $"{Path.GetFileNameWithoutExtension(destination_file_name)}.mp3";
                                    }
                                    DestinationFilePath = Path.GetFullPath(Path.Combine(output_directory, destination_file_name));
                                }
                                if (download_progress_group.Success)
                                {
                                    DownloadProgressString = download_progress_group.Value;
                                }
                                if (file_size_group.Success)
                                {
                                    FileSizeString = file_size_group.Value;
                                }
                                if (download_speed_group.Success)
                                {
                                    DownloadSpeedString = download_speed_group.Value;
                                }
                                if (eta_group.Success)
                                {
                                    ETAString = eta_group.Value;
                                }
                                if (elapsed_time_group.Success)
                                {
                                    ElapsedTimeString = elapsed_time_group.Value;
                                }
                                YouTubeDownloadStatus = EYouTubeDownloadStatus.Downloading;
                            }
                            else
                            {
                                Match ffmpeg_output_line_match = ffmpegOutputLineRegex.Match(line);
                                if (ffmpeg_output_line_match.Success)
                                {
                                    Group destination_file_name_group = ffmpeg_output_line_match.Groups["destinationFileName"];
                                    if (destination_file_name_group.Success)
                                    {
                                        DestinationFilePath = Path.GetFullPath(Path.Combine(output_directory, destination_file_name_group.Value));
                                    }
                                    YouTubeDownloadStatus = EYouTubeDownloadStatus.Converting;
                                }
                                else if (line.StartsWith("[youtube]"))
                                {
                                    YouTubeDownloadStatus = EYouTubeDownloadStatus.FetchingInformation;
                                }
                            }
                        }
                    };
                process.Exited += (_, __) => UpateInformationAfterProcessExit(process, true);
                YouTubeDownloadStatus = EYouTubeDownloadStatus.Enqueued;
                lastProcess = process;
                IsDownloading = true;
                DownloadsManager.ProcessQueue.EnqueueProcess(process);
            }
            return ret;
        }

        public bool TerminateCurrentProcess()
        {
            bool ret = (lastProcess != null) && DownloadsManager.ProcessQueue.TerminateAndDequeueProcess(lastProcess);
            if (ret)
            {
                lastExitCode = lastProcess.ExitCode;
                YouTubeDownloadStatus = EYouTubeDownloadStatus.Terminated;
                lastProcess = null;
                IsDownloading = false;
            }
            return ret;
        }

        public bool TerminateAndDequeueCurrentFetchInformationProcess() => !isDownloading && TerminateCurrentProcess();

        public bool TerminateAndDequeueCurrentMP3DownloadProcess() => isDownloading && TerminateCurrentProcess();
    }
}
