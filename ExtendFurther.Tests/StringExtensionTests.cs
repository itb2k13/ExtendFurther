using ExtendIt;
using NUnit.Framework;

namespace ExtendFurther.Tests
{

        [TestFixture]
        public class ExtendFurtherTests
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
        }

}
