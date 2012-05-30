using NUnit.Framework;

namespace code_kata.StringSet.Test
{
    [TestFixture]
    public class StringSetTest
    {

        [Test]
        public void ShouldAddStringAndContainsReturnTrue()
        {
            var stringSet = new StringSet();
            stringSet.Add("Test");
            Assert.IsTrue(stringSet.Contains("Test"));
        }

        [Test]
        public void ShouldRemoveAndContainsReturnFalse()
        {
            var stringSet = new StringSet();
            stringSet.Add("Test");
            Assert.IsTrue(stringSet.Contains("Test"));
            stringSet.Remove("Test");
            Assert.IsFalse(stringSet.Contains("Test"));
        }

        [Test]
        public void ShouldCount()
        {
            var stringSet = new StringSet();
            stringSet.Add("Test");
            stringSet.Add("Test");
            stringSet.Add("Test");
            Assert.AreEqual(3, stringSet.Count);
            
        }

        [Test]
        public void ShouldClearTheSet()
        {
            var stringSet = new StringSet();
            stringSet.Add("Test");
            stringSet.Add("Test");
            stringSet.Add("Test");
            stringSet.Clear();
            Assert.AreEqual(0, stringSet.Count);
            
        }

        [Test]
        public void ShouldEnumerate()
        {
            var stringSet = new StringSet();
            stringSet.Add("Test");
            stringSet.Add("Test");
            stringSet.Add("Test");
            foreach (var test in stringSet)
            {
                Assert.IsTrue(stringSet.Contains(test));
            }
        }

        [Test]
        public void ShouldUnionTwoSet()
        {
            var set1 = new StringSet();
            var set2 = new StringSet();
            set1.Add("Test1");
            set2.Add("Test2");


            StringSet union = set1.Union(set2);

            Assert.AreEqual(2, union.Count);

            Assert.IsTrue( union.Contains("Test1"));
            Assert.IsTrue( union.Contains("Test2"));
        }

        [Test]
        public void ShouldIntersect()
        {
            var set1 = new StringSet();
            var set2 = new StringSet();
            set1.Add("Test1");
            set1.Add("Common1");
            set1.Add("Common2");
            set2.Add("Common1");
            set2.Add("Common2");
            set2.Add("Test2");


            StringSet intersect = set1.Intersect(set2);

            Assert.AreEqual(2, intersect.Count);

            Assert.IsTrue(intersect.Contains("Common1"));
            Assert.IsTrue(intersect.Contains("Common2"));
            
        }

    }
}