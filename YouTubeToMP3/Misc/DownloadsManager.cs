using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace YouTubeToMP3
{
    internal sealed class DownloadsManager : IDownloadsManager
    {
        private static readonly Regex youTubeURLRegex =
            new Regex
            (
                @"(?:http[s]?:\/\/)?(?:(?:www|m)\.)?youtube\.com\/(?:watch|playlist)\?(?:(v|list|index)=([\-0-9A-Z_a-z]*)&?)(?:(v|list|index)=([\-0-9A-Z_a-z]*)&?)?(?:(v|list|index)=([\-0-9A-Z_a-z]*)&?)?",
                RegexOptions.Compiled
            );

        private static readonly Regex youTubeShortenedURLRegex =
            new Regex
            (
                @"(?:http[s]?:\/\/)?(?:(?:www|m)\.)?youtu(?:be(?:-nocookie)?\.com\/embed|\.be)\/([\-0-9A-Z_a-z]*)",
                RegexOptions.Compiled
            );

        private readonly Dictionary<string, YouTubeDownloadStateEvents> youTubeDownloadStateEvents = new Dictionary<string, YouTubeDownloadStateEvents>();

        private readonly Dictionary<string, YouTubeURL> fetchingPlaylistInformationYouTubeURLs = new Dictionary<string, YouTubeURL>();

        private readonly ConcurrentQueue<YouTubeURL> fetchingPlaylistInformationFinishedYouTubeURLQueue = new ConcurrentQueue<YouTubeURL>();

        private readonly ConcurrentQueue<YouTubeURL> fetchedYouTubeURLQueue = new ConcurrentQueue<YouTubeURL>();

        private readonly ConcurrentQueue<IYouTubeDownloadState> notifiedYouTubeDownloadStateUpdateQueue = new ConcurrentQueue<IYouTubeDownloadState>();

        private readonly IDictionary<string, IYouTubeDownloadState> notifiedYouTubeDownloadStateUpdates =
            new Dictionary<string, IYouTubeDownloadState>();

        public IReadOnlyDictionary<string, YouTubeDownloadStateEvents> YouTubeDownloadStateEvents => youTubeDownloadStateEvents;

        public IYouTubeDL YouTubeDL { get; }

        public IProcessQueue ProcessQueue { get; }

        public bool IsFetchingPlaylistInformation => fetchingPlaylistInformationYouTubeURLs.Count > 0;

        public event YouTubeDownloadStateAddedDelegate OnYouTubeDownloadStateAdded;

        public event YouTubeDownloadStateUpdatedDelegate OnYouTubeDownloadStateUpdated;

        public event YouTubeDownloadStateRemovedDelegate OnYouTubeDownloadStateRemoved;

        public event FetchingPlaylistInformationStartedDelegate OnFetchingPlaylistInformationStarted;

        public event FetchingPlaylistInformationFinishedDelegate OnFetchingPlaylistInformationFinished;

        public DownloadsManager(IYouTubeDL youTubeDL, uint maximalConcurrentlyRunningProcessCount)
        {
            YouTubeDL = youTubeDL ?? throw new ArgumentNullException(nameof(youTubeDL));
            ProcessQueue = new ProcessQueue(maximalConcurrentlyRunningProcessCount);
        }

        public void AddYouTubeURLsFromString(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            foreach (Match match in youTubeURLRegex.Matches(inputString))
            {
                string video_id = string.Empty;
                string playlist_id = string.Empty;
                for (int key_index = 1; (key_index + 1) < match.Groups.Count; key_index += 2)
                {
                    switch (match.Groups[key_index].Value)
                    {
                        case "v":
                            video_id = match.Groups[key_index + 1].Value;
                            break;
                        case "list":
                            playlist_id = match.Groups[key_index + 1].Value;
                            break;
                    }
                }
                if (YouTubeURL.TryCreatingYouTubeURL(video_id, playlist_id, out YouTubeURL you_tube_url))
                {
                    if (you_tube_url.IsVideoIDContained)
                    {
                        AddYouTubeURL(you_tube_url);
                    }
                    if (you_tube_url.IsAPlaylist && !fetchingPlaylistInformationYouTubeURLs.ContainsKey(you_tube_url.PlaylistID))
                    {
                        YouTubeURL playlist_youtube_url = you_tube_url.PlaylistOnly;
                        bool was_fetching_playlist_information = IsFetchingPlaylistInformation;
                        fetchingPlaylistInformationYouTubeURLs.Add(playlist_youtube_url.PlaylistID, playlist_youtube_url);
                        Process process = YouTubeDL.CreateNewFetchPlaylistVideoIDsProcess(you_tube_url, false);
                        process.OutputDataReceived +=
                            (_, e) =>
                            {
                                if ((e.Data != null) && YouTubeURL.TryCreatingYouTubeURLFromVideoID(e.Data, out YouTubeURL fetched_you_tube_url))
                                {
                                    fetchedYouTubeURLQueue.Enqueue(fetched_you_tube_url);
                                }
                            };
                        process.Exited += (_, __) => fetchingPlaylistInformationFinishedYouTubeURLQueue.Enqueue(playlist_youtube_url);
                        if (!was_fetching_playlist_information)
                        {
                            OnFetchingPlaylistInformationStarted?.Invoke(playlist_youtube_url);
                        }
                        ProcessQueue.EnqueueProcess(process);
                    }
                }
            }
            foreach (Match match in youTubeShortenedURLRegex.Matches(inputString))
            {
                if (match.Groups.Count >= 1)
                {
                    if (YouTubeURL.TryCreatingYouTubeURLFromVideoID(match.Groups[1].Value, out YouTubeURL youTubeURL))
                    {
                        AddYouTubeURL(youTubeURL);
                    }
                }
            }
        }

        public IYouTubeDownloadState AddYouTubeURL(YouTubeURL youTubeURL)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("YouTube URL needs to contain a video ID.", nameof(youTubeURL));
            }
            if (!youTubeDownloadStateEvents.TryGetValue(youTubeURL.VideoID, out YouTubeDownloadStateEvents you_tube_download_state_events))
            {
                IYouTubeDownloadState you_tube_download_state = new YouTubeDownloadState(youTubeURL.VideoIDOnly, this);
                you_tube_download_state_events =
                    new YouTubeDownloadStateEvents
                    (
                        you_tube_download_state,
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state),
                        (_, __) => notifiedYouTubeDownloadStateUpdateQueue.Enqueue(you_tube_download_state)
                    );
                you_tube_download_state.OnDownloadEnabledStateChanged += you_tube_download_state_events.OnDownloadEnabledStateChanged;
                you_tube_download_state.OnDownloadStateChanged += you_tube_download_state_events.OnDownloadStateChanged;
                you_tube_download_state.OnYouTubeDownloadStatusChanged += you_tube_download_state_events.OnYouTubeDownloadStatusChanged;
                you_tube_download_state.OnTitleChanged += you_tube_download_state_events.OnTitleChanged;
                you_tube_download_state.OnChannelNameChanged += you_tube_download_state_events.OnChannelNameChanged;
                you_tube_download_state.OnDestinationFilePathChanged += you_tube_download_state_events.OnDestinationFilePathChanged;
                you_tube_download_state.OnDownloadProgressStringChanged += you_tube_download_state_events.OnProgressChanged;
                you_tube_download_state.OnFileSizeStringChanged += you_tube_download_state_events.OnFileSizeStringChanged;
                you_tube_download_state.OnDownloadSpeedStringChanged += you_tube_download_state_events.OnDownloadSpeedStringChanged;
                you_tube_download_state.OnETAStringChanged += you_tube_download_state_events.OnETAStringChanged;
                you_tube_download_state.OnElapsedTimeStringChanged += you_tube_download_state_events.OnElapsedTimeStringChanged;
                youTubeDownloadStateEvents.Add(youTubeURL.VideoID, you_tube_download_state_events);
                OnYouTubeDownloadStateAdded?.Invoke(you_tube_download_state);
            }
            return you_tube_download_state_events.YouTubeDownloadState;
        }

        public bool RemoveYouTubeURL(YouTubeURL youTubeURL)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("YouTube URL needs to contain a video ID.", nameof(youTubeURL));
            }
            string video_id = youTubeURL.VideoID;
            bool ret = youTubeDownloadStateEvents.TryGetValue(video_id, out YouTubeDownloadStateEvents you_tube_download_state_events);
            if (ret)
            {
                you_tube_download_state_events.YouTubeDownloadState.OnDownloadEnabledStateChanged -=
                    you_tube_download_state_events.OnDownloadEnabledStateChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnDownloadStateChanged -=
                    you_tube_download_state_events.OnDownloadStateChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnYouTubeDownloadStatusChanged -=
                    you_tube_download_state_events.OnYouTubeDownloadStatusChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnTitleChanged -=
                    you_tube_download_state_events.OnTitleChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnChannelNameChanged -=
                    you_tube_download_state_events.OnChannelNameChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnDestinationFilePathChanged -=
                    you_tube_download_state_events.OnDestinationFilePathChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnDownloadProgressStringChanged -=
                    you_tube_download_state_events.OnProgressChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnFileSizeStringChanged -=
                    you_tube_download_state_events.OnFileSizeStringChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnDownloadSpeedStringChanged -=
                    you_tube_download_state_events.OnDownloadSpeedStringChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnETAStringChanged -=
                    you_tube_download_state_events.OnETAStringChanged;
                you_tube_download_state_events.YouTubeDownloadState.OnElapsedTimeStringChanged -=
                    you_tube_download_state_events.OnElapsedTimeStringChanged;
                youTubeDownloadStateEvents.Remove(video_id);
                OnYouTubeDownloadStateRemoved?.Invoke(you_tube_download_state_events.YouTubeDownloadState);
            }
            return ret;
        }

        public void EnqueueMP3Downloads(string outputDirectory, bool isEnqueueingOnlyRemainingEntries)
        {
            if (string.IsNullOrWhiteSpace(outputDirectory))
            {
                throw new ArgumentNullException(nameof(outputDirectory));
            }
            foreach (YouTubeDownloadStateEvents you_tube_download_state_events in youTubeDownloadStateEvents.Values)
            {
                if
                (
                    you_tube_download_state_events.YouTubeDownloadState.IsDownloadEnabled &&
                    (!isEnqueueingOnlyRemainingEntries || (you_tube_download_state_events.YouTubeDownloadState.YouTubeDownloadStatus != EYouTubeDownloadStatus.Finished))
                )
                {
                    you_tube_download_state_events.YouTubeDownloadState.EnqueueMP3Download(outputDirectory);
                }
            }
        }

        public void TerminateAndDequeueAllMP3DownloadProcesses()
        {
            foreach (YouTubeDownloadStateEvents you_tube_download_state_events in youTubeDownloadStateEvents.Values)
            {
                you_tube_download_state_events.YouTubeDownloadState.TerminateAndDequeueCurrentMP3DownloadProcess();
            }
        }

        public void ProcessEvents()
        {
            while (fetchedYouTubeURLQueue.TryDequeue(out YouTubeURL fetched_you_tube_url))
            {
                AddYouTubeURL(fetched_you_tube_url);
            }
            while (fetchingPlaylistInformationFinishedYouTubeURLQueue.TryDequeue(out YouTubeURL you_tube_url))
            {
                if (fetchingPlaylistInformationYouTubeURLs.Remove(you_tube_url.PlaylistID))
                {
                    OnFetchingPlaylistInformationFinished?.Invoke(you_tube_url);
                }
            }
            while (notifiedYouTubeDownloadStateUpdateQueue.TryDequeue(out IYouTubeDownloadState you_tube_download_state))
            {
                string video_id = you_tube_download_state.YouTubeURL.VideoID;
                if (!notifiedYouTubeDownloadStateUpdates.ContainsKey(video_id))
                {
                    notifiedYouTubeDownloadStateUpdates.Add(video_id, you_tube_download_state);
                }
            }
            foreach (IYouTubeDownloadState notified_you_tube_download_state_update in notifiedYouTubeDownloadStateUpdates.Values)
            {
                OnYouTubeDownloadStateUpdated?.Invoke(notified_you_tube_download_state_update);
            }
            notifiedYouTubeDownloadStateUpdates.Clear();
            ProcessQueue.ProcessProcessEvents();
        }
    }
}
