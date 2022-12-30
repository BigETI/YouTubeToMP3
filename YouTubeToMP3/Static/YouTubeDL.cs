using System;
using System.Diagnostics;

namespace YouTubeToMP3
{
    public static class YouTubeDL
    {
        private static Process CreateNewProcess(string arguments, bool isStartingProcess)
        {
            Process ret =
                new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo =
                        new ProcessStartInfo
                        {
                            FileName = "youtube-dl",
                            //FileName = "timeout",
                            Arguments = arguments,
                            //Arguments = "/t 5",
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden,
                        }
                };
            if (isStartingProcess)
            {
                ret.Start();
            }
            return ret;
        }

        public static Process CreateNewFetchVideoOrPlaylistInformationProcess(YouTubeURL youTubeURL) =>
            CreateNewFetchVideoOrPlaylistInformationProcess(youTubeURL, true);


        public static Process CreateNewFetchVideoOrPlaylistInformationProcess(YouTubeURL youTubeURL, bool isStartingProcess)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("Specifed YouTube URL needs to contain a video ID.", nameof(youTubeURL));
            }
            return CreateNewProcess($"--dump-single-json \"{youTubeURL}\"", isStartingProcess);
        }

        public static Process CreateNewFetchPlaylistVideoIDsProcess(YouTubeURL youTubeURL) =>
            CreateNewFetchPlaylistVideoIDsProcess(youTubeURL, true);

        public static Process CreateNewFetchPlaylistVideoIDsProcess(YouTubeURL youTubeURL, bool isStartingProcess)
        {
            if (!youTubeURL.IsAPlaylist)
            {
                throw new ArgumentException("Specifed YouTube URL needs to be a playlist.", nameof(youTubeURL));
            }
            return CreateNewProcess($"--get-id \"{youTubeURL.PlaylistOnly}\"", isStartingProcess);
        }

        public static Process CreateNewDownloadVideoToMP3Process(YouTubeURL youTubeURL, string outputDirectory) =>
            CreateNewDownloadVideoToMP3Process(youTubeURL, outputDirectory, true);

        public static Process CreateNewDownloadVideoToMP3Process(YouTubeURL youTubeURL, string outputDirectory, bool isStartingProcess)
        {
            if (!youTubeURL.IsVideoIDContained)
            {
                throw new ArgumentException("Specifed YouTube URL needs to contain a video ID.", nameof(youTubeURL));
            }
            return
                CreateNewProcess
                (
                    $"-f bestaudio -x --audio-format mp3 --prefer-ffmpeg --newline -o \"{(((outputDirectory != null) && (outputDirectory.Length > 0)) ? $"{outputDirectory}/" : string.Empty)}%(title)s.%(ext)s\" \"{youTubeURL.VideoIDOnly}\"",
                    isStartingProcess
                );
        }
    }
}
