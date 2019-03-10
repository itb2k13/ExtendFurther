using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExtendFurther
{
    public static class StringExtensions
    {
        public static bool ContainsString(this string s, string t)
        {
            return s.ToLower().Contains(t.ToLower());
        }
        public static string Coalesce(this List<string> s, string defaultIfNon = null)
        {
            return s.FirstOrDefault(t => !string.IsNullOrEmpty(t)) ?? defaultIfNon ?? string.Empty;
        }
        public static bool Is(this string s, string t)
        {
            return !string.IsNullOrEmpty(s) && s.Equals(t, StringComparison.InvariantCultureIgnoreCase);
        }
        public static DateTime ToDate(this string s)
        {
            return Convert.ToDateTime(s);
        }
        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }

        public static string Comma(this string s, string t)
        {
            return $"{s},{t}";
        }

        public static string YorN(this bool b)
        {
            return b ? "Y" : "N";
        }
        public static string YesOrNo(this bool b)
        {
            return b ? "Yes" : "No";
        }

        public static string Or(this string s, string t)
        {
            return string.IsNullOrEmpty(s) ? t : s;
        }

        public static bool IsNotNullOrEmptyOrWhitespaceOrZero(this string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s) || "0".Equals(s, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static decimal ToDecimalOrZero(this string s)
        {
            try { return Convert.ToDecimal(s); }
            catch { return 0; }
        }

        public static bool IsInt(this string s)
        {
            try { Convert.ToInt32(s); return true; }
            catch { return false; }
        }

        public static bool IsIn(this string s, IEnumerable<string> t)
        {
            return s != null && t.Any(x => x.Equals(s, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool IsAsc(this string s)
        {
            return string.IsNullOrEmpty(s) || new List<string>() { "asc", "ascending" }.Contains(s.ToLower());
        }

        public static bool EqualTo(this string s, string t)
        {
            return (s == null & t == null) || (s != null && t != null && s.Equals(t, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool IsDesc(this string s)
        {
            return s != null && s.Trim().IsIn(new List<string> { "desc", "descending" });
        }

        public static bool Eq(this string s, string t)
        {
            return s != null && s.Equals(t, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsNotIn(this string s, IEnumerable<string> t)
        {
            return !s.IsIn(t);
        }

        public static List<string> ToList(this NameValueCollection n)
        {
            return ((string[])n.AllKeys).ToList();
        }

        public static decimal MaxMin(this decimal d, decimal max, decimal min)
        {
            return d > max ? max : d < min ? min : d;
        }

        public static string GetSafeFilename(this string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static string NoSpace(this string s)
        {
            return !string.IsNullOrEmpty(s) ? s.Replace(" ", "") : string.Empty;
        }

        public static bool IsGuid(this string s)
        {
            Guid guid;
            return Guid.TryParse(s, out guid);
        }

        public static Guid ToGuid(this string s)
        {
            return Guid.Parse(s);
        }

        public static SemVersion ToSemVersion(this string s)
        {
            return new SemVersion(s);
        }

        public static bool ToBool(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            if (
                s.Trim().Equals("true", StringComparison.InvariantCultureIgnoreCase)
                ||
                s.Trim().Equals("yes", StringComparison.InvariantCultureIgnoreCase)
                ||
                s.Trim().Equals("1")
                ||
                (s.IsInt() && s.ToInt() >= 1)
                )
                return true;
            else
                return false;

        }

        public static bool IsNoE(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsValidEmail(this string s)
        {
            return !string.IsNullOrEmpty(s) && new EmailAddressAttribute().IsValid(s);
        }
        public static int? ToNullableInt(this string s)
        {
            if (string.IsNullOrEmpty(s) || s == "--") return null;
            return Convert.ToInt32(GetValueAsNullable<decimal>(s));
        }
        public static double? ToNullableDouble(this string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            return Convert.ToDouble(GetValueAsNullable<double>(s));
        }

        public static T? GetValueAsNullable<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString)) return new Nullable<T>();

            return (T)Convert.ChangeType(valueAsString, typeof(T), CultureInfo.InvariantCulture);
        }

        public static bool IsUri(this string s)
        {
            return Uri.IsWellFormedUriString(s, UriKind.Absolute);
        }

        public static string ToUSPhoneNumberFormat(this string s)
        {
            if ($"{s}".Length == 10)
                return $"({s.Substring(0, 3)}) {s.Substring(3, 3)}-{s.Substring(6, 4)}";
            else
                return s;
        }

        /// <summary>
        /// Determines whether the string is null, empty or whitespace.
        /// </summary>
        /// <param name="s">The string to check for existence.</param>
        /// <returns>True if the string is NOT null, empty or whitespace. False if the string IS empty, null or whitespace.</returns>
        public static bool Exists(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Returns the first N characters of a string
        /// </summary>
        /// <param name="s">The string from which to return N characters</param>
        /// <param name="n">How many characters (N) to return from the start of the string.</param>
        /// <returns>A string of the first N characters.</returns>
        public static string FirstN(this string s, int n)
        {
            return !string.IsNullOrEmpty(s) && n >= 0 ? s.Substring(0, Math.Min(s.Length, n)) : string.Empty;
        }

        public static DateTime FromTimestamp(this string s)
        {
            return s.IsInt() ?
                new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(Int64.Parse(s)).ToLocalTime() :
                DateTime.Parse(s);
        }

        public static string SanitizePhoneNumber(this string phone, string c)
        {
            if (!String.IsNullOrEmpty(phone))
            {
                return phone.Replace(c, string.Empty);
            }

            return phone;

        }

        public static string Truncate(this string value, int maxChars)
        {
            return string.IsNullOrWhiteSpace(value) ? "" : (value.Length <= maxChars ? value : value.Substring(0, maxChars));
        }

        public static string TruncateAndAppend(this string value, int maxChars, string append)
        {
            return string.IsNullOrWhiteSpace(value) ? "" : (value.Length <= maxChars ? value : value.Substring(0, maxChars) + append);
        }

        public static string ToTitleCase(this string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }

        public static string NoSpaceLower(this string s)
        {
            return s.NoSpace().ToLower();
        }

        /// <summary>
        /// Splits a string into substrings based on the input string.
        /// </summary>
        /// <param name="s">The string to split</param>
        /// <param name="t">The string to tokenize by</param>
        /// <returns>A collection of strings</returns>
        public static IEnumerable<string> Split(this string s, string t)
        {
            return !string.IsNullOrEmpty(s) ? s.Split(new string[] { t }, StringSplitOptions.None) : new string[0];
        }
        

        /// <summary>
        /// Splits a string by inserting a space between each lowercase and uppercase letter
        /// </summary>
        /// <param name="input">The camelcase string to split</param>
        /// <returns>A string with spaces</returns>
        public static string SplitCamelCase(this string input)
        {
            return !input.IsNoE() ? System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim() : string.Empty;
        }


        /// <summary>
        /// Determines whether a string starts with any of the entries in the collection (case-insensitive).
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool StartsWithAny(this string s, IEnumerable<string> t)
        {
            return !string.IsNullOrEmpty(s) && t != null && t.Count() > 0 && t.Any(x => s.StartsWith(x, System.StringComparison.OrdinalIgnoreCase));
        }


        /// <summary>
        /// Determines whether a string ends with any of the entries in the collection (Case-insensitive).
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool EndsWithAny(this string s, IEnumerable<string> t)
        {
            return !string.IsNullOrEmpty(s) && t != null && t.Count() > 0 && t.Any(x => s.EndsWith(x, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
