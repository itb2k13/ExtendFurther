namespace ExtendFurther
{
    public static class BooleanExtensions
    {
        public static string YorN(this bool b)
        {
            return b ? "Y" : "N";
        }

        public static string YesOrNo(this bool b)
        {
            return b ? "Yes" : "No";
        }
    }
}
