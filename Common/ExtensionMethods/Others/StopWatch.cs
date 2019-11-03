using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Jbpc.Common.ExtensionMethods
{
    public static class StopWatchExtensionMethods
    {
        public static string ElapsedTimeMessage(this Stopwatch stopwatch)
        {
            var timeSpan = stopwatch.Elapsed;

            if (timeSpan.Hours > 0) return $"hh:mm={timeSpan.Hours}:{timeSpan.Minutes:00}";

            return timeSpan.TotalMinutes > 1 ? $"mm:ss{timeSpan.Minutes:0}:{timeSpan.Seconds:00}" : $"secs={timeSpan.TotalSeconds:F1}";
        }
        public static TimeSpan PerformTimedTask(this Stopwatch stopwatch, Action timedAction)
        {
            stopwatch.Restart();

            try
            {
                timedAction.Invoke();

            }
            catch (Exception)
            {
                throw;
            }

            return stopwatch.Elapsed;
        }
        public static async Task<TimeSpan> PerformTimedTaskAsync(this Stopwatch stopwatch, Action timedTask)
        {
            stopwatch.Restart();

            await Task.Run(timedTask).ConfigureAwait(true);

            return new TimeSpan(stopwatch.ElapsedTicks);
        }
    }
}
