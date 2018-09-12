using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendFurther
{
    public static class GenericExtensions
    {
        public static Type GetRealType<T>(this T source)
        {
            return typeof(T);
        }
    }
}
