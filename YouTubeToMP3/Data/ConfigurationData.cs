using System.Runtime.Serialization;

namespace YouTubeToMP3.Data
{
    [DataContract]
    internal sealed class ConfigurationData : IConfigurationData
    {
        private static readonly string defaultMP3DownloadsDirectoryPath = "./MP3";

        private bool isMaximalConcurrentlyRunningProcessCountLimitDisabled;

        private uint maximalConcurrentDownloadCount = 4U;

        private bool isAddingYouTubeURLsAutomaticallyFromClipboard = true;

        private bool isFetchingVideoInformationAutomatically = true;

        private string mp3DownloadsDirectoryPath = defaultMP3DownloadsDirectoryPath;

        [DataMember(Name = "isMaximalConcurrentlyRunningProcessCountLimitDisabled")]
        public bool IsMaximalConcurrentlyRunningProcessCountLimitDisabled
        {
            get => isMaximalConcurrentlyRunningProcessCountLimitDisabled;
            set => isMaximalConcurrentlyRunningProcessCountLimitDisabled = value;
        }

        [DataMember(Name = "maximalConcurrentDownloads")]
        public uint MaximalConcurrentlyRunningProcessCount
        {
            get => maximalConcurrentDownloadCount;
            set => maximalConcurrentDownloadCount = (value > 0U) ? value : 1U;
        }

        [DataMember(Name = "isAddingYouTubeURLsAutomaticallyFromClipboard")]
        public bool IsAddingYouTubeURLsAutomaticallyFromClipboard
        {
            get => isAddingYouTubeURLsAutomaticallyFromClipboard;
            set => isAddingYouTubeURLsAutomaticallyFromClipboard = value;
        }

        [DataMember(Name = "isFetchingVideoInformationAutomatically")]
        public bool IsFetchingVideoInformationAutomatically
        {
            get => isFetchingVideoInformationAutomatically;
            set => isFetchingVideoInformationAutomatically = value;
        }


        [DataMember(Name = "mp3DownloadsDirectoryPath")]
        public string MP3DownloadsDirectoryPath
        {
            get => mp3DownloadsDirectoryPath ?? defaultMP3DownloadsDirectoryPath;
            set => mp3DownloadsDirectoryPath = value ?? defaultMP3DownloadsDirectoryPath;
        }
    }
}
