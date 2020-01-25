using System;
using System.Globalization;

namespace Jbpc.Common.ExtensionMethods
{
    public static class DateTimeExtensionMethods
    {
        public static string Quarter(this DateTime d)
        {
            switch (d.Month)
            {
                case 1:
                case 2:
                case 3: return "Q1";
                case 4:
                case 5:
                case 6: return "Q2";
                case 7:
                case 8:
                case 9: return "Q3";
                case 10:
                case 11:
                case 12: return "Q4";
                default: throw new System.ApplicationException($"unknown month={d.Month}");
            }
        }
        public static DateTime TruncateToJustDate(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day);
        }
        public static DateTime TruncateToJustSecond(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
        }
        public static bool IsSameToTheMinute(this DateTime x, DateTime y)
        {
            var a = new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, 0);
            var b = new DateTime(y.Year, y.Month, y.Day, y.Hour, y.Minute, 0);

            return a.Equals(b);
        }
        public static int DaysApart(this DateTime d1, DateTime d2)
        {
            return d2.TruncateToJustDate().Subtract(d1.TruncateToJustDate()).Duration().Days;
        }
        public static string AbbreviatedDayName(this DateTime dateTime)
        {
            var culture = DateTimeFormatInfo.CurrentInfo;

            if (culture == null) return "n/a";

            var names = culture.AbbreviatedDayNames;

            DayOfWeek day = dateTime.DayOfWeek;

            return names[(int)day];
        }
        public static string DayOfTheWeekAbbrev(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday: return "Sun";
                case DayOfWeek.Monday: return "Mon";
                case DayOfWeek.Tuesday: return "Tue";
                case DayOfWeek.Wednesday: return "Wed";
                case DayOfWeek.Thursday: return "Thr";
                case DayOfWeek.Friday: return "Fri";
                case DayOfWeek.Saturday: return "Sat";
                default: throw new ApplicationException($"Day of the week unknown={dateTime.DayOfWeek}");
            }
        }
    }
}
