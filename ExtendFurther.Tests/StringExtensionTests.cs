using NUnit.Framework;

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
        [TestCase("", "", false)]
        [TestCase(null, null, false)]
        [TestCase(null, "abc", false)]
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
        public void Extension_StringExtension_Truncate(string s, int maxChars, string expectedResult)
        {
            Assert.That(s.Truncate(maxChars), Is.EqualTo(expectedResult));
        }

    }
}


