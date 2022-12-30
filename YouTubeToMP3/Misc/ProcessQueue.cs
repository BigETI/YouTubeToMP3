using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace YouTubeToMP3
{
    internal sealed class ProcessQueue : IProcessQueue
    {
        private readonly List<Process> enqueuedProcesses = new List<Process>();

        private readonly List<Process> runningProcesses = new List<Process>();

        private readonly ConcurrentQueue<Process> processTerminatedQueue = new ConcurrentQueue<Process>();

        private readonly ConcurrentQueue<Process> processDisposedQueue = new ConcurrentQueue<Process>();

        private uint maximalConcurrentRunningProcessCount;

        public uint MaximalConcurrentlyRunningProcessCount
        {
            get => maximalConcurrentRunningProcessCount;
            set
            {
                if (value <= 0U)
                {
                    throw new ArgumentException("Maximal concurrent running process count needs to be a positive number.", nameof(maximalConcurrentRunningProcessCount));
                }
                maximalConcurrentRunningProcessCount = value;
            }
        }

        public ProcessQueue(uint maximalConcurrentlyRunningProcessCount) =>
            MaximalConcurrentlyRunningProcessCount = maximalConcurrentlyRunningProcessCount;

        private void ProcessExitedEvent(object sender, EventArgs e)
        {
            if (sender is Process process)
            {
                processTerminatedQueue.Enqueue(process);
            }
        }

        private void ProcessDisposedEvent(object sender, EventArgs e)
        {
            if (sender is Process process)
            {
                processDisposedQueue.Enqueue(process);
            }
        }

        public void EnqueueProcess(Process process)
        {
            process.Exited += ProcessExitedEvent;
            process.Disposed += ProcessDisposedEvent;
            if (runningProcesses.Count < maximalConcurrentRunningProcessCount)
            {
                if (process.Start())
                {
                    process.BeginOutputReadLine();
                    runningProcesses.Add(process);
                }
            }
            else
            {
                enqueuedProcesses.Insert(0, process);
            }
        }

        public bool TerminateAndDequeueProcess(Process process)
        {
            bool ret = runningProcesses.Remove(process);
            ret = enqueuedProcesses.Remove(process) || ret;
            if (ret)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // ...
                }
            }
            return ret;
        }

        public void ProcessProcessEvents()
        {
            while (processTerminatedQueue.TryDequeue(out Process process))
            {
                bool is_not_disposed = enqueuedProcesses.Remove(process);
                is_not_disposed = runningProcesses.Remove(process) || is_not_disposed;
                if (is_not_disposed)
                {
                    process.Dispose();
                }
            }
            while (processDisposedQueue.TryDequeue(out Process process))
            {
                enqueuedProcesses.Remove(process);
                runningProcesses.Remove(process);
                process.Exited -= ProcessExitedEvent;
                process.Disposed -= ProcessDisposedEvent;
            }
            while ((runningProcesses.Count < maximalConcurrentRunningProcessCount) && (enqueuedProcesses.Count > 0))
            {
                int enqueued_process_index = enqueuedProcesses.Count - 1;
                Process running_process = enqueuedProcesses[enqueued_process_index];
                enqueuedProcesses.RemoveAt(enqueued_process_index);
                if (running_process.Start())
                {
                    running_process.BeginOutputReadLine();
                    runningProcesses.Add(running_process);
                }
            }
        }
    }
}
