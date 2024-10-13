using System.Diagnostics;

namespace YouTubeToMP3
{
    public interface IYTDLP
    {
        string ExecutablePath { get; }

        Process CreateNewFetchVideoOrPlaylistInformationProcess(YouTubeURL youTubeURL);

        Process CreateNewFetchVideoOrPlaylistInformationProcess(YouTubeURL youTubeURL, bool isStartingProcess);

        Process CreateNewFetchPlaylistVideoIDsProcess(YouTubeURL youTubeURL);

        Process CreateNewFetchPlaylistVideoIDsProcess(YouTubeURL youTubeURL, bool isStartingProcess);

        Process CreateNewDownloadVideoToMP3Process(YouTubeURL youTubeURL, string outputDirectory);

        Process CreateNewDownloadVideoToMP3Process(YouTubeURL youTubeURL, string outputDirectory, bool isStartingProcess);
    }
}
