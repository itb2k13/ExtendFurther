
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

        [Test]
        [TestCase(0, 0)]
        [TestCase(0.00, 0)]
        [TestCase(1.449999999, 1)]
        [TestCase(1.3, 1)]
        [TestCase(1.53423432, 2)]
        [TestCase(1.555555, 2)]
        [TestCase(-1.555555, -2)]
        public void Extension_NumericalExtension_Round0Dp_Rounds_To_Zero_Decimal_Places(decimal d, decimal expectedOutcome)
        {
            Assert.That(d.Round0Dp(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(0.00, 0, 0)]
        [TestCase(1.53423432, 0, 2)]
        [TestCase(1.555555, 0, 2)]
        [TestCase(-1.555555, 0, -2)]
        [TestCase(0, 1, 0.0)]
        [TestCase(0.00, 1, 0.00)]
        [TestCase(1.53423432, 1, 1.5)]
        [TestCase(1.555555, 1, 1.6)]
        [TestCase(-1.555555, 1, -1.6)]
        public void Extension_NumericalExtension_Rnd_Rounds_To_Expected_Decimal_Places(decimal d, int decimalPlaces, decimal expectedOutcome)
        {
            Assert.That(d.Rnd(decimalPlaces), Is.EqualTo(expectedOutcome));
        }
    }
}


