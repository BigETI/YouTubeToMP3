using System.Collections.Generic;

namespace YouTubeToMP3
{
    public interface IDownloadsManager
    {
        IReadOnlyDictionary<string, YouTubeDownloadStateEvents> YouTubeDownloadStateEvents { get; }

        IProcessQueue ProcessQueue { get; }

        bool IsFetchingPlaylistInformation { get; }

        event YouTubeDownloadStateAddedDelegate OnYouTubeDownloadStateAdded;

        event YouTubeDownloadStateUpdatedDelegate OnYouTubeDownloadStateUpdated;

        event YouTubeDownloadStateRemovedDelegate OnYouTubeDownloadStateRemoved;

        event FetchingPlaylistInformationStartedDelegate OnFetchingPlaylistInformationStarted;

        event FetchingPlaylistInformationFinishedDelegate OnFetchingPlaylistInformationFinished;

        void AddYouTubeURLsFromString(string inputString);

        IYouTubeDownloadState AddYouTubeURL(YouTubeURL youTubeURL);

        bool RemoveYouTubeURL(YouTubeURL youTubeURL);

        void EnqueueMP3Downloads(string outputDirectory, bool isEnqueueingOnlyRemainingEntries);

        void TerminateAndDequeueAllMP3DownloadProcesses();

        void ProcessEvents();
    }
}
