using ExtendIt;
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
        public void ExtensionListExtensionDeterminesIfItemsInListAreDistinct(string[] s, bool isDistinct)
        {
            Assert.That(s.ToList().IsDistinct, Is.EqualTo(isDistinct));
        }
    }
}
