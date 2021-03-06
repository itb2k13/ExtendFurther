﻿using NUnit.Framework;
using System.Linq;

namespace ExtendFurther.Tests
{

    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase(" ", false)]
        [TestCase("abc", true)]
        public void Extension_StringExtension_Exists(string s, bool expectedOutcome)
        {
            Assert.That(s.Exists(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase("", "", false)]
        [TestCase(null, null, false)]
        [TestCase(" ", " ", false)]
        [TestCase("abc", "", true)]
        [TestCase("abc", "abc", false)]
        [TestCase("abc", "aBc", false)]
        public void Extension_StringExtension_ExistsAndNot(string s, string t, bool expectedOutcome)
        {
            Assert.That(s.ExistsAndNot(t), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase("", 3, "")]
        [TestCase(null, 3, "")]
        [TestCase("abc", 3, "abc")]
        [TestCase("a", 3, "a")]
        [TestCase("abcdefgh", 5, "abcde")]
        [TestCase("abc", 0, "")]
        [TestCase("a", -1, "")]
        public void Extension_StringExtension_FirstN_Returns_First_N_Chars_Of_String(string s, int n, string expectedResult)
        {
            Assert.That(s.FirstN(n), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", "", true)]
        [TestCase(null, null, true)]
        [TestCase("abc", "ABC", true)]
        [TestCase("123", "123", true)]
        [TestCase("", "123", false)]
        [TestCase("abc", "def", false)]
        [TestCase(null, "def", false)]
        [TestCase("abc", null, false)]
        public void Extension_StringExtension_IsEqualTo(string s, string t, bool expectedResult)
        {
            Assert.That(s.EqualTo(t), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase(" ", false)]
        [TestCase("test'user@domain.com", true)]
        [TestCase("a@b.com", true)]
        [TestCase("user@domain.com", true)]
        [TestCase("test.user@domain.com", true)]
        [TestCase("user@dom.edu.co.uk", true)]
        public void Extension_StringExtension_Validates_Email_Addresses(string s, bool expectedResult)
        {
            Assert.That(s.IsValidEmail(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase(" ", false)]
        [TestCase("abc", false)]
        public void Extension_StringExtension_IsNoE(string s, bool expectedResult)
        {
            Assert.That(s.IsNoE(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", "", ",")]
        [TestCase(null, null, ",")]
        [TestCase("a", "b", "a,b")]
        [TestCase("abc", "def", "abc,def")]
        public void Extension_StringExtension_Comma(string s, string t, string expectedResult)
        {
            Assert.That(s.Comma(t), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", "", false)]
        [TestCase(null, null, false)]
        [TestCase(null, "abc", false)]
        [TestCase("abc", null, false)]
        [TestCase(" ", " ", true)]
        [TestCase("abc", "abc", true)]
        [TestCase("ABC", "abc", true)]
        [TestCase("aBc", "AbC", true)]
        public void Extension_StringExtension_Is(string s, string t, bool expectedResult)
        {
            Assert.That(s.Is(t), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", 0, "")]
        [TestCase(null, 0, "")]
        [TestCase(" ", 0, "")]
        [TestCase("abc", 0, "")]
        [TestCase("", 3, "")]
        [TestCase(null, 3, "")]
        [TestCase(" ", 3, "")]
        [TestCase("abc", 3, "abc")]
        [TestCase("abcdefghi", 4, "abcd")]
        [TestCase("the quick brown fox", 6, "the qu")]
        public void Extension_StringExtension_Truncate(string s, int maxChars, string expectedResult)
        {
            Assert.That(s.Truncate(maxChars), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(0, "This Month")]
        [TestCase(1, "Last Month")]
        [TestCase(12, "This Year")]
        [TestCase(24, "Last Year")]
        [TestCase(50, "Last 50 Months")]
        public void Extension_StringExtension_ToDateRangeFilterOption(int i, string expectedResult)
        {
            Assert.That(i.ToDateRangeFilterOption(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", "", "")]
        [TestCase(null, "", "")]
        [TestCase("abc", "", "abc")]
        [TestCase("a b c", "", "abc")]
        [TestCase("A BC", "", "ABC")]
        [TestCase("A BC", "_", "A_BC")]
        [TestCase("A B C", "&", "A&B&C")]
        public void Extension_StringExtension_NoSpace(string s, string t, string expectedResult)
        {
            Assert.That(s.NoSpace(t), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("abc", "abc")]
        [TestCase("a b c", "abc")]
        [TestCase("A BC", "abc")]
        public void Extension_StringExtension_NoSpaceLower(string s, string expectedResult)
        {
            Assert.That(s.NoSpaceLower(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", null)]
        [TestCase(null, null)]
        [TestCase("TestSettingNotExists", null)]
        [TestCase("TestSettingOne", "abc")]
        [TestCase("TestSettingTwo", "1234")]
        public void Extension_StringExtension_FromConfig_String(string s, string expectedResult)
        {
            Assert.That(s.FromConfig<string>(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", null)]
        [TestCase(null, null)]
        [TestCase("TestSettingNotExists", null)]
        [TestCase("TestSettingThree", 999)]
        public void Extension_StringExtension_FromConfig_Integer(string s, int? expectedResult)
        {
            Assert.That(s.FromConfig<int?>(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", null)]
        [TestCase(null, null)]
        [TestCase("TestSettingNotExists", null)]
        [TestCase("TestSettingFour", true)]
        [TestCase("TestSettingFive", false)]
        public void Extension_StringExtension_FromConfig_Bool(string s, bool? expectedResult)
        {
            Assert.That(s.FromConfig<bool?>(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("abc", "abc")]
        [TestCase("abcde", "abcde")]
        [TestCase("abcdefghi", "abcde...")]
        [TestCase("abcdefghi", "abcde###", "###")]
        public void Extension_StringExtension_TruncateAndAppend(string s, string expectedResult, string append = "...")
        {
            Assert.That(s.TruncateAndAppend(5, append), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", new string[] { }, false)]
        [TestCase(null, new string[] { }, false)]
        [TestCase("abc", new string[] { "a", "x" }, true)]
        [TestCase("a b c", new string[] { "a", "b", "c" }, true)]
        [TestCase("xyz", new string[] { "a", "b" }, false)]
        public void Extension_StringExtension_ContainsAnyOf(string s, string[] t, bool expectedResult)
        {
            Assert.That(s.ContainsAnyOf(t), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", "", new string[] { })]
        [TestCase(null, "", new string[] { })]
        [TestCase("abc", ";", new string[] { "abc" })]
        [TestCase("a b c", " ", new string[] { "a", "b", "c" })]
        [TestCase("a;BC", ";", new string[] { "a", "BC" })]
        public void Extension_StringExtension_Split(string s, string t, string[] expectedResult)
        {
            Assert.That(s.SplitBy(t), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("abc", "abc")]
        [TestCase("a b c", "a b c")]
        [TestCase("ABC", "A B C")]
        [TestCase("AbC", "Ab C")]
        [TestCase("OneTwoThree.", "One Two Three.")]
        [TestCase("CamelCase", "Camel Case")]
        public void Extension_StringExtension_SplitCamelCase(string s, string expectedResult)
        {
            Assert.That(s.SplitCamelCase(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("123", true)]
        [TestCase("567", true)]
        [TestCase("row", true)]
        [TestCase("UiC", true)]
        [TestCase("bob", false)]
        public void Extension_StringExtension_IsContainedIn(string s, bool expectedResult)
        {
            Assert.That(s.IsPartOfAny("quick", "brown", "123", "45678"), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("0", false)]
        [TestCase(null, false)]
        [TestCase("abc", true)]
        [TestCase("a b c", true)]
        [TestCase("   ", false)]
        public void Extension_StringExtension_IsNotNullOrEmptyOrZero(string s, bool expectedResult)
        {
            Assert.That(s.IsNotNullOrEmptyOrWhitespaceOrZero, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("0", false)]
        [TestCase(null, false)]
        [TestCase("   ", false)]
        [TestCase("desc", true)]
        [TestCase("     desc    ", true)]
        [TestCase("Desc", true)]
        [TestCase("DESC", true)]
        [TestCase("descending", true)]
        [TestCase("DesCENding", true)]
        [TestCase("DESCENDING", true)]
        public void Extension_StringExtension_IsDesc(string s, bool expectedResult)
        {
            Assert.That(s.IsDesc, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("0", false)]
        [TestCase("-1", false)]
        [TestCase("   ", false)]
        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("100", true)]
        [TestCase("true", true)]
        [TestCase("TRUE ", true)]
        [TestCase("tRUe", true)]
        [TestCase("Yes", true)]
        [TestCase("yEs ", true)]
        [TestCase("y ", true)]
        [TestCase("Y ", true)]
        public void Extension_StringExtension_ToBool(string s, bool expectedResult)
        {
            Assert.That(s.ToBool(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("123.456", "123.456")]
        [TestCase("123.000", "123")]
        [TestCase("123.45600", "123.456")]
        [TestCase("123.0101", "123.0101")]
        [TestCase("123.010", "123.01")]
        [TestCase("000.000", "000")]
        [TestCase("123.", "123")]
        public void Extension_StringExtension_TrimZeros(string s, string expectedResult)
        {
            Assert.That(s.TrimZeros(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("abc", "abc")]
        [TestCase("123.456000", "123.46")]
        [TestCase("123.000000", "123")]
        [TestCase("123.5", "123.5")]
        public void Extension_StringExtension_RoundAndTrimZeros(string s, string expectedResult)
        {
            Assert.That(s.Round(2).TrimZeros(), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("abc", "abc")]
        [TestCase("123.456", "123.46")]
        [TestCase("123.000", "123.00")]
        [TestCase("123.45600", "123.46")]
        [TestCase("123.0101", "123.01")]
        [TestCase("123.010", "123.01")]
        [TestCase("000.000", "0.00")]
        [TestCase("123.", "123.00")]
        public void Extension_StringExtension_Round(string s, string expectedResult)
        {
            Assert.That(s.Round(2), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", new string[0], false)]
        [TestCase("", null, false)]
        [TestCase(null, null, false)]
        [TestCase("abc", new string[2] { "ABC", "def" }, true)]
        [TestCase("abc", new string[2] { "xABCy", "def" }, false)]
        [TestCase("ABC", new string[2] { "abc def", "def" }, false)]
        [TestCase("DEF", new string[2] { "abc def", "def" }, true)]
        public void Extension_StringExtension_StartsWithAny(string t, string[] s, bool expectedResult)
        {
            Assert.That(t.StartsWithAny(s?.ToList()), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("hello world", "68656c6c6f20776f726c64")]
        public void Extension_StringExtension_ToHex(string s, string expectedResult)
        {
            Assert.That(s.ToHex(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(null, new byte[0])]
        [TestCase("", new byte[0])]
        [TestCase("abc", new byte[3] { 97, 98, 99 })]
        public void Extension_StringExtension_ToBytes(string s, byte[] expectedResult)
        {
            Assert.That(s.ToBytes(), Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(null, null, "")]
        [TestCase("", "", "")]
        [TestCase("abc", "abc", "")]
        [TestCase("abc123", "123", "abc")]
        [TestCase("abc", "xyz", "abc")]
        public void Extensions_StringExtension_TrimEndOf(string s, string trim, string expectedString)
        {
            Assert.AreEqual(expectedString, s.TrimEndOf(trim));
        }


        [Test]
        [TestCase(null, null, -1)]
        [TestCase("", "", -1)]
        [TestCase(" ", "", -1)]
        [TestCase("123", "0123456789", -1)]
        [TestCase("abc 123", "0123456789", 4)]
        [TestCase(" abc 123", "0123456789", 4)]
        [TestCase("K-9 abc 123", "0123456789", 8)]
        [TestCase(" K-9 abc 123", "0123456789", 8)]
        [TestCase(" K-9 abc 123 xyz", "xy", 12)]
        [TestCase("K-9 abc 123 xyz", "XYZ", 12)]
        [TestCase("K-9 abc 123 xyz", "zyx", 12)]
        [TestCase("K9Z abc 123 xyz", "zy", 13)]
        public void Extensions_StringExtension_IndexOfAnyAfterFirstWord(string s, string indexOf, int expectedResult)
        {
            Assert.AreEqual(expectedResult, s.IndexOfAnyAfterFirstWord(indexOf));
        }


        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase("123 &amp; 456", "123 & 456")]
        public void Extensions_StringExtension_HtmlDecode(string s, string expectedString)
        {
            Assert.AreEqual(expectedString, s.HtmlDecode());
        }

        [Test]
        [TestCase(null, null, false)]
        [TestCase("", "", true)]
        [TestCase(" ", " ", true)]
        [TestCase("123 &amp; 456", "456", false)]
        [TestCase("def", "DEF", true)]
        public void Extensions_StringExtension_IsIn(string s, string t, bool expectedResult)
        {
            Assert.That(t.IsIn(s), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("123", true)]
        [TestCase("def", true)]
        public void Extensions_StringExtension_IsIn_Params(string s, bool expectedResult)
        {
            Assert.That(s.IsIn("abc", "def", "hij", "123"), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, null, null, false)]
        [TestCase("", "", "", false)]
        [TestCase(" ", " ", " ", false)]
        [TestCase("123 &amp; 456", "456", ";", false)]
        [TestCase("def&hij", "DEF", "&", true)]
        [TestCase("8.8.8.8", "8.8.8.8", ";", true)]
        public void Extensions_StringExtension_IsIn_SplitBy(string s, string t, string u, bool expectedResult)
        {
            Assert.That(t.IsIn(s, u), Is.EqualTo(expectedResult));
        }
    }
}
