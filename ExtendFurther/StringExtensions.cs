using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtendFurther
{
    public static class StringExtensions
    {
        public static bool ContainsString(this string s, string t)
        {
            return s.ToLower().Contains(t.ToLower());
        }

        public static bool ContainsAnyOf(this string s, IEnumerable<string> t)
        {
            return t.Count() > 0 && !string.IsNullOrEmpty(s) && t.Any(x => !string.IsNullOrEmpty(x) && s.ToLower().Contains(x.ToLower()));
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

        public static bool IsLong(this string s)
        {
            try { Convert.ToInt64(s); return true; }
            catch { return false; }
        }

        public static bool IsIn(this string s, IEnumerable<string> t)
        {
            return s != null && t.Any(x => x.Equals(s, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool IsIn(this string s, params string[] t)
        {
            return s != null && t.Count() > 0 && t.Any(x => x.Equals(s, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool IsIn(this string s, string t, string u)
        {
            return s != null && t != null && (t.Split(u)?.Any(x => x.Equals(s, StringComparison.InvariantCultureIgnoreCase)) ?? false);
        }

        public static bool IsPartOfAny(this string s, params string[] t)
        {
            return s.Exists() && t.Any(x => x.ContainsString(s));
        }

        public static bool IsAsc(this string s)
        {
            return string.IsNullOrEmpty(s) || s.IsIn(new List<string> { "asc", "ascending" });
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

        public static string GetSafeFilename(this string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Returns the string with spaces replaced for emptystring (default) or optional replacement string t
        /// </summary>
        /// <param name="s">The input string</param>
        /// <param name="t">The optional replacement string for any spaces</param>
        /// <returns></returns>
        public static string NoSpace(this string s, string t = "")
        {
            return !string.IsNullOrEmpty(s) ? s.Replace(" ", t) : string.Empty;
        }

        public static bool IsGuid(this string s)
        {
            Guid guid;
            return Guid.TryParse(s, out guid);
        }

        public static Guid ToGuid(this string s)
        {
            return s.IsGuid() ? Guid.Parse(s) : Guid.Empty;
        }

        public static SemVersion ToSemVersion(this string s)
        {
            return new SemVersion(s);
        }

        public static bool ToBool(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            if (s.Trim().IsIn(new List<string> { "true", "yes", "1", "Y" })
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
            var regEx = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            return !string.IsNullOrEmpty(s) && regEx.Match(s).Length > 0;
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
        /// Determines whether the string is null, empty or whitespace and not equal to the input (case in-sensitive).
        /// </summary>
        /// <param name="s">The string to check for existence.</param>
        /// <param name="t">The string to check for equality.</param>
        /// <returns>True if the string is NOT null, empty or whitespace or equal to the param t. False if the string IS empty, null or whitespace or equal to param t.</returns>
        public static bool ExistsAndNot(this string s, string t)
        {
            return !string.IsNullOrWhiteSpace(s) && !s.Eq(t);
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
            return s.IsLong() ?
                new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(long.Parse(s)).ToLocalTime() :
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

        /// <summary>
        /// Truncates a string safely to the specified number of characters. If the string is shorter then returns just the string.
        /// </summary>
        /// <param name="s">The string to truncate</param>
        /// <param name="maxChars">How many chars to truncate from the left</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string s, int maxChars)
        {
            return string.IsNullOrWhiteSpace(s) ? "" : (s.Length <= maxChars ? s : s.Substring(0, maxChars));
        }

        /// <summary>
        /// Truncates a string safely to the specified number of characters and appends the specified string to the end. If the string is shorter than maxChars then just the string is returned with no appendage.
        /// </summary>
        /// <param name="s">The string to truncate and append</param>
        /// <param name="maxChars">How many chars to truncate from the left</param>
        /// <param name="append">A string to append to the end if the input string is longer than the truncated value</param>
        /// <returns>The truncated string with optional appendage</returns>
        public static string TruncateAndAppend(this string s, int maxChars, string append = "")
        {
            return string.IsNullOrWhiteSpace(s) ? "" : (s.Length <= maxChars ? s : s.Substring(0, maxChars) + append);
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
        /// Performs a case-insensitive string replacement
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replaceThis"></param>
        /// <param name="withThis"></param>
        /// <returns></returns>
        public static string ReplaceInsensitive(this string str, string replaceThis, string withThis)
        {
            return Regex.Replace(str, replaceThis, withThis, RegexOptions.IgnoreCase);
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

        /// <summary>
        /// Trims the trailing zeros from the string if it contains a decimal point
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TrimZeros(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            else return s.Contains(".") ? s.TrimEnd('0').TrimEnd('.') : s;
        }

        /// <summary>
        /// Determines if the input string can be converted to a decimal representation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string s)
        {
            decimal d;
            return decimal.TryParse(s, out d);
        }

        /// <summary>
        /// Rounds a string decimal to specified number of places and then returns it back as a string
        /// </summary>
        /// <param name="s">The input decimal string</param>
        /// <param name="rounding">How many decimal places to round to</param>
        /// <returns></returns>
        public static string Round(this string s, int rounding)
        {
            if (!s.Exists() || !s.IsDecimal()) return s;
            else return Math.Round(Convert.ToDecimal(s), rounding).ToString("N2");
        }

        /// <summary>
        /// Returns the relevant config variable based on the input key
        /// </summary>
        /// <param name="key">Config key</param>
        /// <returns></returns>
        public static T FromConfig<T>(this string key)
        {
            object value = ConfigurationManager.AppSettings[key];
            try { return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value.ToString()); }
            catch { return default(T); }
        }

        /// <summary>
        /// Returns the string as a byte array
        /// </summary>
        /// <param name="s">The input string</param>
        /// <returns>The string as an array of bytes</returns>
        public static byte[] ToBytes(this string s)
        {
            return s.Exists() ? Encoding.ASCII.GetBytes(s) : new byte[0];
        }

        /// <summary>
        /// Returns the string's hexadecimal representation
        /// </summary>
        /// <param name="s">The input string</param>
        /// <returns>The hexadecimal representation of the string without hyphens in lowercase</returns>
        public static string ToHex(this string s)
        {
            return s.Exists() ? BitConverter.ToString(s.ToBytes()).Replace("-", "").ToLower() : "";
        }

        /// <summary>
        /// Trims the specified string from the end of the input string
        /// </summary>
        /// <param name="input">The input string to trim</param>
        /// <param name="suffixToRemove">The string to remove from the end of the input</param>
        /// <returns>A new string with the specified string removed from the end</returns>
        public static string TrimEndOf(this string input, string suffixToRemove)
        {
            if (!input.Exists() || !suffixToRemove.Exists())
                return string.Empty;

            int pos = input.LastIndexOf(suffixToRemove, StringComparison.CurrentCultureIgnoreCase);

            if (pos == (input.Length - suffixToRemove.Length))
                return input.Substring(0, pos);

            return input;
        }

        /// <summary>
        /// Returns the index of any of the characters in the specified string ignoring matches in the first word (split by space) (case insensitive).
        /// </summary>
        /// <param name="s">The string to search</param>
        /// <param name="indexOf">The integer position of the search or -1 if not found</param>
        /// <returns>The position of the search string ignoring matches found in the first word</returns>
        public static int IndexOfAnyAfterFirstWord(this string s, string indexOf)
        {
            if (!s.Exists())
                return -1;

            s = s.Trim();

            if (s.IndexOf(" ") > 0)
                return s.ToLower().IndexOfAny(indexOf.ToLower().ToCharArray(), s.IndexOf(" "));
            else
                return -1;
        }


        /// <summary>
        /// Returns the string with HTML decoding
        /// </summary>
        /// <param name="s">The input string to decode</param>
        /// <returns>A new string with any HTML characters decoded</returns>
        public static string HtmlDecode(this string s)
        {
            return WebUtility.HtmlDecode(s);
        }

    }
}
