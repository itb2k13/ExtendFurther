﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ExtendFurther.Tests
{
    class TestModel
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
    }

    [TestFixture]
    public class CollectionExtensionTests
    {
        [Test]
        [TestCase(new string[] { "", "" }, false)]
        [TestCase(new string[] { "" }, true)]
        [TestCase(new string[] { "a", "b" }, true)]
        [TestCase(new string[] { "a", "b", "b" }, false)]
        public void Extension_ListExtension_IsDistinct_Determines_If_Items_In_List_Are_Distinct(string[] s, bool isDistinct)
        {
            Assert.That(s.ToList().IsDistinct, Is.EqualTo(isDistinct));
        }

        [Test]
        [TestCase(new string[] { "a", "b", "c", "d" }, null)]
        public void Extension_ListExtension_Rand(string[] values, int i)
        {
            Assert.That(values.Contains(values.Rand()));
        }

        [Test]
        [TestCase(new int[] { 1, -100, 3123, -12331 }, null)]
        public void Extension_ListExtension_Rand(int[] values, int i)
        {
            Assert.That(values.Contains(values.Rand()));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-10, -45)]
        [TestCase(10, 45)]
        [TestCase(500, 124750)]
        public void Extension_ListExtension_Enumerator(int i, int sum)
        {
            var en = i.Enumerator();

            Assert.That(en.Sum(), Is.EqualTo(sum));
            Assert.That(en.Count(), Is.EqualTo(i.Abs()));

            for (int j = i - 1; j >= 0; j--)
            {
                Assert.That(i.Enumerator().Contains(j), Is.True);
            }
        }

        [Test]
        [TestCase(null, ";", "")]
        [TestCase(new string[] { }, ";", "")]
        [TestCase(new string[] { "abc" }, ";", "abc")]
        [TestCase(new string[] { "a", "b", "c", "d", "e" }, ";", "a;b;c;d;e")]
        public void Extension_ListExtension_JoinBy(string[] values, string separator, string expectedValue)
        {            
            Assert.That(values.JoinBy(separator), Is.EqualTo(expectedValue));
        }


        [Test]
        [TestCase(null, ";", -1, null)]
        [TestCase(new string[] { }, "", 0, new string[] { })]
        [TestCase(new string[] { }, ";", 0, new string[] { })]
        [TestCase(new string[] { ";abc" }, ";", 0, new string[] { "" })]
        [TestCase(new string[] { "abc;", ";abc" }, ";", 0, new string[] { "abc", "" })]
        [TestCase(new string[] { "abc" }, ";", 0, new string[] { "abc" })]
        [TestCase(new string[] { "abc:def", "xyz:abc" }, ":", 0, new string[] { "abc", "xyz" })]
        [TestCase(new string[] { "abc def", "xyz abc" }, " ", 1, new string[] { "def", "abc" })]
        [TestCase(new string[] { "abc:def", "xyz:abc" }, ";", 1, new string[] { "abc:def", "xyz:abc" })]
        [TestCase(new string[] { "abc:def", "xyz:abc" }, ":", 10, new string[] { "abc:def", "xyz:abc" })]
        [TestCase(new string[] { "abc:def", "xyz;abc" }, ":", 0, new string[] { "abc", "xyz;abc" })]
        public void Extension_ListExtension_SafeSplit(string[] values, string separator, int index, string[] expectedValue)
        {
            Assert.That(values.SafeSplit(separator, index), Is.EqualTo(expectedValue));
        }


        [Test]
        public void Extension_CollectionExtension_MaxBy()
        {
            var a = new TestModel { Prop1 = 1, Prop2 = "xyz" };
            var b = new TestModel { Prop1 = 2, Prop2 = "abc" };
            var c = new List<TestModel> { a, b };

            Assert.That(c.MaxBy(x => x.Prop1), Is.SameAs(b));
            Assert.That(c.MaxBy(x => x.Prop2), Is.SameAs(a));
        }

        [Test]
        public void Extension_CollectionExtension_MinBy()
        {
            var a = new TestModel { Prop1 = 1, Prop2 = "xyz" };
            var b = new TestModel { Prop1 = 2, Prop2 = "abc" };
            var c = new List<TestModel> { a, b };

            Assert.That(c.MinBy(x => x.Prop1), Is.SameAs(a));
            Assert.That(c.MinBy(x => x.Prop2), Is.SameAs(b));
        }

    }
}
