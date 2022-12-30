namespace YouTubeToMP3
{
    public interface IConfigurationData
    {
        bool IsMaximalConcurrentlyRunningProcessCountLimitDisabled { get; set; }

        uint MaximalConcurrentlyRunningProcessCount { get; set; }

        bool IsAddingYouTubeURLsAutomaticallyFromClipboard { get; set; }

        bool IsFetchingVideoInformationAutomatically { get; set; }

        string MP3DownloadsDirectoryPath { get; set; }
    }
}
