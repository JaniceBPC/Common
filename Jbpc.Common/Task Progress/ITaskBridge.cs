using System;

namespace Jbpc.Common
{
    public interface ITaskBridge
    {
        void PerformStep(Action action, TaskProgress taskProgress);
        void ReportProgress(TaskProgress taskProgress, string message);
        void ReportComplete(TaskProgress taskProgress, TimeSpan timeSpan);
        void CancelOnRequest();
        void ReportComplete();
        void PerformActionOnUIThread(Action action);

    }
}
