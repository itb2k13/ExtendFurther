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
        [TestCase(-1, -1)]
        [TestCase(-99, -99)]
        [TestCase(1.1, 2)]
        [TestCase(191.0123, 192)]
        public void Extension_NumericalExtension_RoundUpToInt(double i, int expectedOutcome)
        {
            Assert.That(i.RoundUpToInt(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(-99, -99)]
        [TestCase(1.1, 1)]
        [TestCase(191.0123, 191)]
        [TestCase(128.5, 128)]
        public void Extension_NumericalExtension_RoundDownToInt(double i, int expectedOutcome)
        {
            Assert.That(i.RoundDownToInt(), Is.EqualTo(expectedOutcome));
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
            Assert.That(NumericalExtensions.Round(d, decimalPlaces), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 10)]
        [TestCase(0, 1)]
        [TestCase(0, 1)]
        [TestCase(5, 100)]
        [TestCase(-5, 100)]
        [TestCase(-5, -100)]
        [TestCase(-5, 0)]
        [TestCase(-50000, 100)]
        [TestCase(100, 100)]
        [TestCase(-100, -100)]
        public void Extension_NumericalExtension_Rand(int i, int j)
        {
            Assert.That(i.RandBetween(j), Is.GreaterThanOrEqualTo(i < j ? i : j).And.LessThanOrEqualTo(i < j ? j : i));
        }

        [Test]
        [TestCase("0", true)]
        [TestCase("1234", true)]
        [TestCase("141421451", true)]
        [TestCase("-1", true)]
        [TestCase("-23232323", true)]
        [TestCase("abc", false)]
        [TestCase("1.1234", false)]
        public void Extension_NumericalExtension_IsNumeric(string s, bool expectedOutcome)
        {
            Assert.That(s.IsInt(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase(0, 0, 0, "-79228162514264337593543950335")]
        [TestCase(52, 100, 2, "52")]
        [TestCase(33, 100, 5, "33")]
        [TestCase(8, 512, 5, "1.5625")]
        [TestCase(123213923, 1227389721, 3, "10.039")]
        public void Extension_NumericalExtension_AsAPercentOf(decimal d, decimal e, int decimalPlaces, decimal expectedOutcome)
        {
            Assert.That(d.AsAPercentOf(e, decimalPlaces), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 10, 0, 1)]
        [TestCase(100, 10, 0, 10)]
        [TestCase(-10, 10, 0, 0)]
        public void Extension_NumericalExtension_MaxMin(decimal d, decimal max, decimal min, decimal expectedResult)
        {
            Assert.That(d.MaxMin(max, min), Is.EqualTo(expectedResult));
        }
    }
}


