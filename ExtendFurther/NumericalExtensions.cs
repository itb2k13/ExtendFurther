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

        public static decimal Minus(this decimal d, int percent)
        {
            return Math.Round(d - (d * (percent / 100)));
        }

        public static bool ToBool(this int i)
        {
            return i >= 1;
        }

        public static decimal Rnd(this decimal d, int i)
        {
            return Math.Round(d, i);
        }
    }
}
