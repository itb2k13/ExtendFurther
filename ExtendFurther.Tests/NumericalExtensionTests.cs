
using NUnit.Framework;

namespace ExtendFurther.Tests
{

    [TestFixture]
    public class NumericalExtensionTests
    {
        [Test]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(-99, false)]
        [TestCase(1, true)]
        [TestCase(99, true)]
        public void Extension_NumericalExtension_ToBool(int i, bool expectedOutcome)
        {
            Assert.That(i.ToBool(), Is.EqualTo(expectedOutcome));
        }
        
    }
}


