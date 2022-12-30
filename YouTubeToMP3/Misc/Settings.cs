using System;
using System.IO;
using System.Runtime.Serialization.Json;
using YouTubeToMP3.Data;

namespace YouTubeToMP3
{
    internal sealed class Settings : ISettings
    {
        private static readonly DataContractJsonSerializer configurationDataContractJSONSerializer = new DataContractJsonSerializer(typeof(ConfigurationData));

        private ConfigurationData configurationData;

        public bool IsMaximalConcurrentlyRunningProcessCountLimitDisabled
        {
            get => configurationData.IsMaximalConcurrentlyRunningProcessCountLimitDisabled;
            set
            {
                if (configurationData.IsMaximalConcurrentlyRunningProcessCountLimitDisabled != value)
                {
                    bool was_maximal_concurrently_running_process_count_limit_disabled = configurationData.IsMaximalConcurrentlyRunningProcessCountLimitDisabled;
                    configurationData.IsMaximalConcurrentlyRunningProcessCountLimitDisabled = value;
                    OnMaximalConcurrentlyRunningProcessCountLimitStateChanged?.Invoke(was_maximal_concurrently_running_process_count_limit_disabled, value);
                }
            }
        }

        public uint MaximalConcurrentlyRunningProcessCount
        {
            get => configurationData.MaximalConcurrentlyRunningProcessCount;
            set
            {
                if (configurationData.MaximalConcurrentlyRunningProcessCount != value)
                {
                    uint old_maximal_concurrently_running_process_count = configurationData.MaximalConcurrentlyRunningProcessCount;
                    configurationData.MaximalConcurrentlyRunningProcessCount = value;
                    OnMaximalConcurrentlyRunningProcessCountChanged?.Invoke(old_maximal_concurrently_running_process_count, value);
                }
            }
        }

        public bool IsAddingYouTubeURLsAutomaticallyFromClipboard
        {
            get => configurationData.IsAddingYouTubeURLsAutomaticallyFromClipboard;
            set
            {
                if (configurationData.IsAddingYouTubeURLsAutomaticallyFromClipboard != value)
                {
                    bool was_adding_you_tube_urls_automatically_from_clipboard = configurationData.IsAddingYouTubeURLsAutomaticallyFromClipboard;
                    configurationData.IsAddingYouTubeURLsAutomaticallyFromClipboard = value;
                    OnAddingYouTubeURLsAutomaticallyFromClipboardStateChanged?.Invoke(was_adding_you_tube_urls_automatically_from_clipboard, value);
                }
            }
        }

        public bool IsFetchingVideoInformationAutomatically
        {
            get => configurationData.IsFetchingVideoInformationAutomatically;
            set
            {
                if (configurationData.IsFetchingVideoInformationAutomatically != value)
                {
                    bool was_fetching_video_information_automatically = configurationData.IsFetchingVideoInformationAutomatically;
                    configurationData.IsFetchingVideoInformationAutomatically = value;
                    OnFetchingVideoInformationAutomaticallyStateChanged?.Invoke(was_fetching_video_information_automatically, value);
                }
            }
        }

        public string MP3DownloadsDirectoryPath
        {
            get => configurationData.MP3DownloadsDirectoryPath;
            set
            {
                if (configurationData.MP3DownloadsDirectoryPath != value)
                {
                    string old_mp3_downloads_directory_path = configurationData.MP3DownloadsDirectoryPath;
                    configurationData.MP3DownloadsDirectoryPath = value;
                    OnMP3DownloadsDirectoryPathChanged?.Invoke(old_mp3_downloads_directory_path, value);
                }
            }
        }

        public event MaximalConcurrentlyRunningProcessCountLimitStateChangedDelegate OnMaximalConcurrentlyRunningProcessCountLimitStateChanged;

        public event MaximalConcurrentlyRunningProcessCountChangedDelegate OnMaximalConcurrentlyRunningProcessCountChanged;

        public event AddingYouTubeURLsAutomaticallyFromClipboardStateChangedDelegate OnAddingYouTubeURLsAutomaticallyFromClipboardStateChanged;

        public event FetchingVideoInformationAutomaticallyStateChangedDelegate OnFetchingVideoInformationAutomaticallyStateChanged;

        public event MP3DownloadsDirectoryPathChangedDelegate OnMP3DownloadsDirectoryPathChanged;

        public Settings(string configurationFilePath) => LoadConfigurationFile(configurationFilePath);

        public bool LoadConfigurationFile(string configurationFilePath)
        {
            bool ret = false;
            ConfigurationData configuration_data = null;
            try
            {
                if (File.Exists(configurationFilePath))
                {
                    using (FileStream configuration_file_stream = File.OpenRead(configurationFilePath))
                    {
                        configuration_data = configurationDataContractJSONSerializer.ReadObject(configuration_file_stream) as ConfigurationData;
                        ret = configuration_data != null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                configurationData = configuration_data ?? configurationData ?? new ConfigurationData();
            }
            return ret;
        }

        public bool SaveConfigurationFile(string configurationFilePath)
        {
            bool ret = false;
            try
            {
                using (FileStream configuration_file_stream = File.Open(configurationFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {

                    configurationDataContractJSONSerializer.WriteObject(configuration_file_stream, configurationData);
                    ret = true;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return ret;
        }
    }
}
