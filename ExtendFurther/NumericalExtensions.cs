using System;
using System.Linq;

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

        public static decimal Minus(this decimal d, int percent)
        {
            return Math.Round(d - (d * (percent / 100)));
        }

        public static decimal AsAPercentOf(this decimal d, decimal o, int decimalPlaces)
        {
            return o != 0 ? (d/o).Rnd(decimalPlaces) : decimal.MinValue;
        }

        public static int RoundUpToInt(this double d)
        {
            return Convert.ToInt32(Math.Ceiling(d));
        }

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
        public static decimal Rnd(this decimal d, int i)
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
