using System.Runtime.Serialization;

namespace YouTubeToMP3.Data
{
    [DataContract]
    internal sealed class YouTubeVideoInformationData
    {
        [DataMember]
        private string title = string.Empty;

        [DataMember(Name = "channel")]
        private string channelName = string.Empty;

        public string Title => title ?? string.Empty;

        public string ChannelName => channelName ?? string.Empty;
    }
}
