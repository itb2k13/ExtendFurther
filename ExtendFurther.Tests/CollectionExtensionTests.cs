
using NUnit.Framework;
using System.Linq;

namespace ExtendFurther.Tests
{
    class CollectionExtensionTests
    {
        [TestCase(new string[] { "", "" }, false)]
        [TestCase(new string[] { "" }, true)]
        [TestCase(new string[] { "a", "b" }, true)]
        [TestCase(new string[] { "a", "b", "b" }, false)]
        public void Extension_ListExtension_IsDistinct_Determines_If_Items_In_List_Are_Distinct(string[] s, bool isDistinct)
        {
            Assert.That(s.ToList().IsDistinct, Is.EqualTo(isDistinct));
        }

        [TestCase(new string[] { "a", "b", "c", "d" }, null)]
        public void Extension_ListExtension_Rand(string[] values, int i)
        {
            Assert.That(values.Contains(values.Rand()));
        }
    }
}
