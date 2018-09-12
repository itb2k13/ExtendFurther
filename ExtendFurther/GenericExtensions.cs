using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendIt
{
    public static class GenericExtensions
    {
        public static Type GetRealType<T>(this T source)
        {
            return typeof(T);
        }
    }
}
