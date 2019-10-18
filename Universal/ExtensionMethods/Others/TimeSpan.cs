
using System;

namespace Universal.ExtensionMethods
{
    public static class TimeSpanExtensionMethods
    {
        public static string FormatSeconds(int numberOfseconds)
        {
            if (numberOfseconds < 60) return numberOfseconds.ToString();
            if (numberOfseconds < 60 * 60) return TimeSpan.FromSeconds(numberOfseconds).ToString(@"mm\:ss");

            return TimeSpan.FromSeconds(numberOfseconds).ToString(@"hh\:mm\:ss");
        }
        public static TimeSpan AddSeconds(this TimeSpan? timeSpan, int seconds = 1)
        {
            return  new TimeSpan((timeSpan ?? new TimeSpan()).Ticks + TimeSpan.TicksPerSecond * seconds);
        }
        public static TimeSpan AddSeconds(this TimeSpan timeSpan, int seconds = 1)
        {
            return new TimeSpan(timeSpan.Ticks + TimeSpan.TicksPerSecond * seconds);
        }
        public static string SmartFormat(this TimeSpan timeSpan)
        {
            string msg = timeSpan.Hours == 0 ? "": $"{timeSpan.Hours}:";

            msg = timeSpan.TotalMinutes==0 ? 
                    "":
                    timeSpan.TotalMinutes < 60 ?
                        $"{timeSpan.Minutes}" :
                        $"{msg}{timeSpan.Minutes:00}";

            if (timeSpan.Minutes == 0 && timeSpan.Milliseconds==0)
            {
                return timeSpan.TotalMinutes > 60 ?
                    msg :
                    $"{msg}mins";
            }

            msg = timeSpan.Seconds==0 ?
                "":
                timeSpan.TotalSeconds < 60 ?
                    $"{timeSpan.Seconds}" :
                    $"{msg}{timeSpan.Seconds:00}";

            if (timeSpan.Milliseconds == 0)
            {
                return timeSpan.TotalSeconds>60 ?
                    msg :
                    $"{msg}secs";
            }

            return timeSpan.Milliseconds == 0 ?
                msg :
                timeSpan.TotalSeconds>1 ?
                    $"{timeSpan.TotalSeconds:F2}secs" :
                    $"{timeSpan.TotalMilliseconds / 1000D:F1}ms";
        }
    }
}