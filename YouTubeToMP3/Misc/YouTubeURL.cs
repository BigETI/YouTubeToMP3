using System;
using System.Collections.Generic;

namespace YouTubeToMP3
{
    public readonly struct YouTubeURL : IComparable<YouTubeURL>, IEquatable<YouTubeURL>
    {
        private static readonly string youTubeURLHost = "https://www.youtube.com/";

        public string VideoID { get; }

        public string PlaylistID { get; }

        public bool IsVideoIDContained => VideoID.Length > 0;

        public bool IsAPlaylist => PlaylistID.Length > 0;

        public YouTubeURL VideoIDOnly
        {
            get
            {
                if (!IsVideoIDContained)
                {
                    throw new InvalidOperationException("YouTube URL does not contain a video ID.");
                }
                return IsAPlaylist ? new YouTubeURL(VideoID, string.Empty) : this;
            }
        }

        public YouTubeURL PlaylistOnly
        {
            get
            {
                if (!IsAPlaylist)
                {
                    throw new InvalidOperationException("YouTube URL is not a playlist.");
                }
                return IsVideoIDContained ? new YouTubeURL(string.Empty, PlaylistID) : this;
            }
        }

        private YouTubeURL(string videoID, string playlistID)
        {
            VideoID = videoID;
            PlaylistID = playlistID;
        }

        private static bool IsStringAValidID(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            bool ret = false;
            foreach (char character in inputString)
            {
                if
                (
                    ((character >= '0') && (character <= '9')) ||
                    ((character >= 'A') && (character <= 'Z')) ||
                    ((character >= 'a') && (character <= 'z')) ||
                    (character == '-') ||
                    (character == '_')
                )
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        public static bool TryCreatingYouTubeURLFromVideoID(string videoID, out YouTubeURL youTubeURL)
        {
            bool ret = IsStringAValidID(videoID);
            youTubeURL = ret ? new YouTubeURL(videoID, string.Empty) : default;
            return ret;
        }

        public static bool TryCreatingYouTubeURLFromPlaylistID(string playlistID, out YouTubeURL youTubeURL)
        {
            bool ret = IsStringAValidID(playlistID);
            youTubeURL = ret ? new YouTubeURL(string.Empty, playlistID) : default;
            return ret;
        }

        public static bool TryCreatingYouTubeURL(string videoID, string playlistID, out YouTubeURL youTubeURL)
        {
            bool is_video_id_valid = IsStringAValidID(videoID);
            bool is_playlist_id_valid = IsStringAValidID(playlistID);
            youTubeURL = new YouTubeURL(is_video_id_valid ? videoID : string.Empty, is_playlist_id_valid ? playlistID : string.Empty);
            return is_video_id_valid || is_playlist_id_valid;
        }

        public static bool operator ==(YouTubeURL left, YouTubeURL right) => left.Equals(right);

        public static bool operator !=(YouTubeURL left, YouTubeURL right) => !left.Equals(right);

        public override string ToString() =>
            IsVideoIDContained ?
                (
                    IsAPlaylist ?
                        $"{youTubeURLHost}watch?v={VideoID}&list={PlaylistID}" :
                        $"{youTubeURLHost}watch?v={VideoID}"
                ) :
                (
                    IsAPlaylist ?
                        $"{youTubeURLHost}playlist?list={PlaylistID}" :
                        youTubeURLHost
                );

        public int CompareTo(YouTubeURL other)
        {
            int ret = VideoID.CompareTo(other.VideoID);
            if (ret == 0)
            {
                ret = PlaylistID.CompareTo(other.PlaylistID);
            }
            return ret;
        }

        public bool Equals(YouTubeURL other) =>
            (VideoID == other.VideoID) &&
            (PlaylistID == other.PlaylistID);

        public override int GetHashCode()
        {
            int hashCode = -585414801;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PlaylistID);
            return hashCode;
        }

        public override bool Equals(object obj) => (obj is YouTubeURL you_tube_url) && Equals(you_tube_url);
    }
}
