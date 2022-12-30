using System;
using System.Windows.Forms;

namespace YouTubeToMP3.Forms
{
    public partial class PreferencesForm : Form
    {
        public ISettings Settings { get; }

        public PreferencesForm(ISettings settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            InitializeComponent();
            disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Checked = Settings.IsMaximalConcurrentlyRunningProcessCountLimitDisabled;
            maximalConcurrentlyRunningProcessCountNumericUpDown.Value = Settings.MaximalConcurrentlyRunningProcessCount;
            outputDirectoryTextBox.Text = Settings.MP3DownloadsDirectoryPath;
            folderBrowserDialog.SelectedPath = Settings.MP3DownloadsDirectoryPath;
        }

        private void DisableMaximalConcurrentlyRunningProcessCountLimitCheckBoxCheckedChangedEvent(object sender, EventArgs e) =>
            Settings.IsMaximalConcurrentlyRunningProcessCountLimitDisabled = disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Checked;

        private void MaximalConcurrentlyRunningProcessCountNumericUpDownValueChangedEvent(object sender, EventArgs e) =>
            Settings.MaximalConcurrentlyRunningProcessCount = (uint)maximalConcurrentlyRunningProcessCountNumericUpDown.Value;

        private void OutputDirectoryTextBoxTextChangedEvent(object sender, EventArgs e)
        {
            Settings.MP3DownloadsDirectoryPath = outputDirectoryTextBox.Text;
            folderBrowserDialog.SelectedPath = Settings.MP3DownloadsDirectoryPath;
        }

        private void SelectOutputDirectoryButtonClickEvent(object sender, EventArgs e)
        {
            DialogResult dialog_result = folderBrowserDialog.ShowDialog();
            DialogResult = DialogResult.None;
            if ((dialog_result == DialogResult.OK) || (dialog_result == DialogResult.Yes))
            {
                Settings.MP3DownloadsDirectoryPath = folderBrowserDialog.SelectedPath;
                outputDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
