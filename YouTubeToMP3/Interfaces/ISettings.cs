namespace YouTubeToMP3
{
    public interface ISettings : IConfigurationData
    {
        event MaximalConcurrentlyRunningProcessCountLimitStateChangedDelegate OnMaximalConcurrentlyRunningProcessCountLimitStateChanged;

        event MaximalConcurrentlyRunningProcessCountChangedDelegate OnMaximalConcurrentlyRunningProcessCountChanged;

        event AddingYouTubeURLsAutomaticallyFromClipboardStateChangedDelegate OnAddingYouTubeURLsAutomaticallyFromClipboardStateChanged;

        event FetchingVideoInformationAutomaticallyStateChangedDelegate OnFetchingVideoInformationAutomaticallyStateChanged;

        event MP3DownloadsDirectoryPathChangedDelegate OnMP3DownloadsDirectoryPathChanged;

        bool LoadConfigurationFile(string configurationFilePath);

        bool SaveConfigurationFile(string configurationFilePath);
    }
}
