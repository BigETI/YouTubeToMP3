namespace YouTubeToMP3
{
    public interface IYouTubeDownloadState
    {
        bool IsDownloadEnabled { get; set; }

        bool IsDownloading { get; }

        EYouTubeDownloadStatus YouTubeDownloadStatus { get; }

        string Title { get; }

        string ChannelName { get; }

        string DestinationFilePath { get; }

        string DownloadProgressString { get; }

        string FileSizeString { get; }

        string DownloadSpeedString { get; }

        string ETAString { get; }

        string ElapsedTimeString { get; }

        int LastExitCode { get; }

        YouTubeURL YouTubeURL { get; }

        IDownloadsManager DownloadsManager { get; }

        event DownloadEnabledStateChangedDelegate OnDownloadEnabledStateChanged;

        event DownloadStateChangedDelegate OnDownloadStateChanged;

        event YouTubeDownloadStatusChangedDelegate OnYouTubeDownloadStatusChanged;

        event TitleChangedDelegate OnTitleChanged;

        event ChannelNameChangedDelegate OnChannelNameChanged;

        event DestinationFilePathChangedDelegate OnDestinationFilePathChanged;

        event DownloadProgressStringChangedDelegate OnDownloadProgressStringChanged;

        event FileSizeStringChangedDelegate OnFileSizeStringChanged;

        event DownloadSpeedStringChangedDelegate OnDownloadSpeedStringChanged;

        event ETAStringChangedDelegate OnETAStringChanged;

        event ElapsedTimeStringChangedDelegate OnElapsedTimeStringChanged;

        bool EnqueueFetchingInformation();

        bool EnqueueMP3Download(string outputDirectory);

        bool TerminateCurrentProcess();

        bool TerminateAndDequeueCurrentFetchInformationProcess();

        bool TerminateAndDequeueCurrentMP3DownloadProcess();
    }
}
