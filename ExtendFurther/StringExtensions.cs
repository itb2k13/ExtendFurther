﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExtendIt
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

        public static string Plus(this string s, string t)
        {
            return $"{s},{t}";
        }

        public static string YorN(this bool b)
        {
            return b ? "Y" : "N";
        }

        public static string Or(this string s, string t)
        {
            return string.IsNullOrEmpty(s) ? t : s;
        }
        public static bool IsNotNullOrEmptyOrZero(this string s)
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

        public static bool IsIn(this string s, List<string> t)
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
            return s.IsIn(new List<string> { "desc", "descending" });
        }

        public static bool Eq(this string s, string t)
        {
            return s != null && s.Equals(t, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsNotIn(this string s, List<string> t)
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
        public static bool IsGuid(this string testString)
        {
            Guid testGuid;
            return Guid.TryParse(testString, out testGuid);
        }
        public static SemVersion ToSemVersion(this string s)
        {
            return new SemVersion(s);
        }
        public static string ToDateRangeFilterOption(this int i)
        {
            return i == 1 ? "Last Month" : i == 12 ? "Last Year" : $"Last {i} Months";
        }
        public static bool ToBool(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            if (
                s.Equals("true", StringComparison.InvariantCultureIgnoreCase)
                ||
                s.Equals("1")
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
        public static bool Exists(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }
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
            return string.IsNullOrWhiteSpace(value) ? "" : (value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...");
        }
        public static string ToTitleCase(this string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }
    }
}
