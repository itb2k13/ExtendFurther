using NUnit.Framework;
using System;

namespace ExtendFurther.Tests
{
    class DateTimeExtensionTests
    {
        [Test]
        public void Extension_DateTimeExtension_ToUtcDateTimeString()
        {
            Assert.That(new DateTime(2018, 9, 20, 14, 34, 13).ToUtcDateTimeString(), Is.EqualTo("2018-09-20T13:34:13.000Z"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(600)]
        [TestCase(123019283)]
        [TestCase(123214)]
        [TestCase(3214325)]
        [TestCase(123)]
        [TestCase(1515)]
        public void Extension_DateTimeExtension_SubtractUtcNow(int timeDiff)
        {
            var futureDateTime = DateTime.UtcNow.AddSeconds(timeDiff).ToUtcDateTimeString();
            Assert.That(futureDateTime.SubtractUtcNow(), Is.EqualTo(timeDiff));
        }

    }
}
