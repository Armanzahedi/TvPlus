using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TvPlus.Utility
{
    public static class Utility
    {
        public static DateTime ConvertToPersian(string date)
        {
            var splitDate = date.Split('/');
            var month = splitDate[0];
            var day = splitDate[1];
            var year = splitDate[2].Split(' ')[0];

            return DateTime.Parse($"{year}/{month}/{day}", new CultureInfo("fa-IR"));
        }

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;

            if (span.Days > 30)
                return String.Format("{0}:{1} - {2}", dt.Hour, dt.Minute, dt.ToPersianString());

            if (span.Days > 0)
                return String.Format("{0} روز پیش",
                span.Days);

            if (span.Hours > 0)
                return String.Format("{0} ساعت پیش",
                span.Hours);

            if (span.Minutes > 0)
                return String.Format("{0} دقیقه پیش",
                span.Minutes);

            if (span.Seconds > 0)
                return "هم اکنون";

            return string.Empty;
        }

        public static string ToPersianString(this DateTime date)
        {
            var pc = new System.Globalization.PersianCalendar();
            var month = pc.GetMonth(date);
            var day = pc.GetDayOfMonth(date);

            var monthStr = month < 10 ? "0" + month : month.ToString();
            var dayStr = day < 10 ? "0" + day : day.ToString();

            return string.Format("{0}/{1}/{2}", pc.GetYear(date), monthStr, dayStr);
        }
        public static string ToPersianString(this DateTime? date)
        {
            if (date == null)
                return "";

            return date.Value.ToPersianString();
        }

        public static string ToPersianStringDateTime(this DateTime date)
        {
            if (date == null)
                return "";

            var hour = date.Hour != 0 ? date.Hour.ToString() : "00";
            var minute = date.Hour != 0 ? date.Minute.ToString() : "00";
            var second = date.Hour != 0 ? date.Second.ToString() : "00";

            return $"{hour}:{minute}:{second}" + " - " + date.ToPersianString();
        }

        public static string ToPersianStringDateTimeRtl(this DateTime date)
        {
            if (date == null)
                return "";

            var hour = date.Hour != 0 ? date.Hour.ToString() : "00";
            var minute = date.Hour != 0 ? date.Minute.ToString() : "00";
            var second = date.Hour != 0 ? date.Second.ToString() : "00";

            return date.ToPersianString() + " - " + $"{hour}:{minute}:{second}";
        }

        public static string TruncateString(this string str, int count)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (str.Length <= count)
                return str;

            return str.Substring(0, count) + "...";
        }
    }
}
