using System;

namespace ExtendFurther
{
    public static class DateTimeExtensions
    {
        public static string ToUtcDateTimeString(this DateTime t)
        {
            return t.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }

        public static int SubtractUtcNow(this string s)
        {
            return Convert.ToInt32(Math.Ceiling(DateTime.Parse(s).Subtract(DateTime.Parse(DateTime.UtcNow.ToUtcDateTimeString())).TotalSeconds));
        }
    }
}
