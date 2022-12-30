using System;

namespace YouTubeToMP3
{
    public readonly struct YouTubeDownloadStateEvents
    {
        public IYouTubeDownloadState YouTubeDownloadState { get; }

        public DownloadEnabledStateChangedDelegate OnDownloadEnabledStateChanged { get; }

        public DownloadStateChangedDelegate OnDownloadStateChanged { get; }

        public YouTubeDownloadStatusChangedDelegate OnYouTubeDownloadStatusChanged { get; }

        public TitleChangedDelegate OnTitleChanged { get; }

        public ChannelNameChangedDelegate OnChannelNameChanged { get; }

        public DestinationFilePathChangedDelegate OnDestinationFilePathChanged { get; }

        public DownloadProgressStringChangedDelegate OnProgressChanged { get; }

        public FileSizeStringChangedDelegate OnFileSizeStringChanged { get; }

        public DownloadSpeedStringChangedDelegate OnDownloadSpeedStringChanged { get; }

        public ETAStringChangedDelegate OnETAStringChanged { get; }

        public ElapsedTimeStringChangedDelegate OnElapsedTimeStringChanged { get; }

        public YouTubeDownloadStateEvents
        (
            IYouTubeDownloadState youTubeDownloadState,
            DownloadEnabledStateChangedDelegate onDownloadEnabledStateChanged,
            DownloadStateChangedDelegate onDownloadStateChanged,
            YouTubeDownloadStatusChangedDelegate onYouTubeDownloadStatusChanged,
            TitleChangedDelegate onTitleChanged,
            ChannelNameChangedDelegate onChannelNameChanged,
            DestinationFilePathChangedDelegate onDestinationFilePathChanged,
            DownloadProgressStringChangedDelegate onProgressChanged,
            FileSizeStringChangedDelegate onFileSizeStringChanged,
            DownloadSpeedStringChangedDelegate onDownloadSpeedStringChanged,
            ETAStringChangedDelegate onETAStringChanged,
            ElapsedTimeStringChangedDelegate onElapsedTimeStringChanged
        )
        {
            YouTubeDownloadState = youTubeDownloadState ?? throw new ArgumentNullException(nameof(youTubeDownloadState));
            OnDownloadEnabledStateChanged = onDownloadEnabledStateChanged ?? throw new ArgumentNullException(nameof(onDownloadEnabledStateChanged));
            OnDownloadStateChanged = onDownloadStateChanged ?? throw new ArgumentNullException(nameof(onDownloadStateChanged));
            OnYouTubeDownloadStatusChanged = onYouTubeDownloadStatusChanged ?? throw new ArgumentNullException(nameof(onYouTubeDownloadStatusChanged));
            OnTitleChanged = onTitleChanged ?? throw new ArgumentNullException(nameof(onTitleChanged));
            OnChannelNameChanged = onChannelNameChanged ?? throw new ArgumentNullException(nameof(onChannelNameChanged));
            OnDestinationFilePathChanged = onDestinationFilePathChanged ?? throw new ArgumentNullException(nameof(onDestinationFilePathChanged));
            OnProgressChanged = onProgressChanged ?? throw new ArgumentNullException(nameof(onProgressChanged));
            OnFileSizeStringChanged = onFileSizeStringChanged ?? throw new ArgumentNullException(nameof(onFileSizeStringChanged));
            OnDownloadSpeedStringChanged = onDownloadSpeedStringChanged ?? throw new ArgumentNullException(nameof(onDownloadSpeedStringChanged));
            OnETAStringChanged = onETAStringChanged ?? throw new ArgumentNullException(nameof(onETAStringChanged));
            OnElapsedTimeStringChanged = onElapsedTimeStringChanged ?? throw new ArgumentNullException(nameof(onElapsedTimeStringChanged));
        }
    }
}
