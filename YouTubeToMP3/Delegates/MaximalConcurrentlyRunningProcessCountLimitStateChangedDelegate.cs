namespace YouTubeToMP3
{
    public delegate void MaximalConcurrentlyRunningProcessCountLimitStateChangedDelegate
    (
        bool oldMaximalConcurrentlyRunningProcessCountLimitState,
        bool newMaximalConcurrentlyRunningProcessCountLimitState
    );
}
