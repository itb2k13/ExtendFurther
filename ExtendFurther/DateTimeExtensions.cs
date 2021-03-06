﻿using System;

namespace ExtendFurther
{
    /// <summary>
    /// Extensions that help with string to DateTime and similar
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Converts a DateTime to a UTC formatted string
        /// </summary>
        /// <param name="t">The DateTime</param>
        /// <returns>UTC formatted string</returns>
        public static string ToUtcDateTimeString(this DateTime t)
        {
            return t.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }

        /// <summary>
        /// Subtracts the DateTime UtcNow from a string representing a DateTime in UTC format
        /// </summary>
        /// <param name="s">Target date string in UTC</param>
        /// <returns>The number of seconds between UtcNow and the input date</returns>
        public static int SubtractUtcNow(this string s)
        {
            return DateTime
                    .Parse(s)
                    .ToUniversalTime()
                    .Subtract(DateTime.UtcNow)
                    .TotalSeconds
                    .RoundUpToInt();
        }

        /// <summary>
        /// Adds a number of seconds to the specified DateTime string
        /// </summary>
        /// <param name="s">The DateTime string</param>
        /// <param name="i">How many seconds to add to the input string</param>
        /// <returns>A new DateTime with the specified number of seconds added</returns>
        public static DateTime AddSeconds(this string s, int i)
        {
            return DateTime.Parse(s).AddSeconds(i);
        }
    }
}
