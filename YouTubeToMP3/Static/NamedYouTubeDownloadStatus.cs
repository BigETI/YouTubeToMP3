using System.Collections.Generic;

namespace YouTubeToMP3
{
    public static class NamedYouTubeDownloadStatus
    {
        private static readonly IReadOnlyDictionary<EYouTubeDownloadStatus, string> humanReadableYouTubeDownloadStatus =
            new Dictionary<EYouTubeDownloadStatus, string>
            {
                { EYouTubeDownloadStatus.Added, "Added" },
                { EYouTubeDownloadStatus.Enqueued, "Enqueued" },
                { EYouTubeDownloadStatus.FetchingInformation, "Fetching information..." },
                { EYouTubeDownloadStatus.Downloading, "Downloading..." },
                { EYouTubeDownloadStatus.Converting, "Converting..." },
                { EYouTubeDownloadStatus.Finished, "Finished!" },
                { EYouTubeDownloadStatus.Terminated, "Terminated!" },
                { EYouTubeDownloadStatus.Error, "Error: {0}" }
            };

        public static string GetYouTubeDownloadStatusName(EYouTubeDownloadStatus youTubeDownloadStatus, int exitCode)
        {
            return humanReadableYouTubeDownloadStatus.TryGetValue(youTubeDownloadStatus, out string human_readable_status) ?
                ((youTubeDownloadStatus == EYouTubeDownloadStatus.Error) ? string.Format(human_readable_status, exitCode) : human_readable_status) :
                youTubeDownloadStatus.ToString();
        }
    }
}
