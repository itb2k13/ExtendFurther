using System;

namespace ExtendFurther
{
    public static class NumericalExtensions
    {
        public static decimal Round0Dp(this decimal d)
        {
            return decimal.Parse(Math.Round(d, 1).ToString("N0"));
        }

        public static decimal Round1Dp(this decimal d)
        {
            return decimal.Parse(Math.Round(d, 1).ToString("N1"));
        }

        public static decimal Round2Dp(this decimal d)
        {
            return decimal.Parse(Math.Round(d, 2).ToString("N2"));
        }

        public static decimal MinusPercent(this decimal d, int percent)
        {
            return Math.Round(d - (d * (percent / 100)));
        }

        /// <summary>
        /// Works out the pecentage of decimal A to decimal B
        /// </summary>
        /// <param name="d">The numerator</param>
        /// <param name="o">The denominator</param>
        /// <param name="decimalPlaces">Rounding to this many decimal places</param>
        /// <returns>The percentage of A to B rounded to the specified number of decimal places</returns>
        public static decimal AsAPercentOf(this decimal d, decimal o, int decimalPlaces)
        {
            return o != 0 ? Round(((d / o) * 100), decimalPlaces) : decimal.MinValue;
        }

        /// <summary>
        /// Rounds the input up to the nearest integer
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int RoundUpToInt(this double d)
        {
            return Convert.ToInt32(Math.Ceiling(d));
        }

        /// <summary>
        /// Rounds down to the nearest integer
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int RoundDownToInt(this double d)
        {
            return Convert.ToInt32(Math.Floor(d));
        }

        /// <summary>
        /// Returns true if the input int is greater than or equal to 1
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool ToBool(this int i)
        {
            return i >= 1;
        }

        /// <summary>
        /// Rounds a decimal to the specified number of decimal places
        /// </summary>
        /// <param name="d"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static decimal Round(this decimal d, int i)
        {
            return Math.Round(d, i);
        }

        public static string ToDateRangeFilterOption(this int i)
        {
            return i <= 0 ? "This Month" : i == 1 ? "Last Month" : i <= 12 ? "This Year" : i <= 24 ? "Last Year" : $"Last {i} Months";
        }

        /// <summary>
        /// Returns a random integer between the extended int and another int
        /// </summary>
        /// <param name="i">The lowest or highest random can be</param>
        /// <param name="j">The lowest or highest random can be</param>
        /// <returns></returns>
        public static int RandBetween(this int i, int j)
        {
            return i < j ?
                 (new Random(Guid.NewGuid().GetHashCode())).Next(i, j + 1) :
                 (new Random(Guid.NewGuid().GetHashCode())).Next(j, i + 1);
        }

    }
}
