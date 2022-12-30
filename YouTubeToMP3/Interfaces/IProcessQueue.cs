using System.Diagnostics;

namespace YouTubeToMP3
{
    public interface IProcessQueue
    {
        uint MaximalConcurrentlyRunningProcessCount { get; set; }

        void EnqueueProcess(Process process);

        bool TerminateAndDequeueProcess(Process process);

        void ProcessProcessEvents();
    }
}
