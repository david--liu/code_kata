using System;
using NUnit.Framework;

namespace code_kata.Range.Test
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ShouldThrowNotSupportedException_WhenLowerIsGreaterThanUpper()
        {
            new Range<int>(100, 10);
        }

        [Test]
        public void ShouldCheckIsInRange()
        {
            var range = new Range<int>(0, 10);
            Assert.IsTrue(range.IsInRange(0));
            Assert.IsTrue(range.IsInRange(1));
            Assert.IsTrue(range.IsInRange(2));
            Assert.IsTrue(range.IsInRange(3));
            Assert.IsTrue(range.IsInRange(10));
            Assert.IsFalse(range.IsInRange(11));
            Assert.IsFalse(range.IsInRange( -1));
        }

        [Test]
        public void Intersect_ShouldReturnNull_WhenNoIntersection()
        {
            var range = new Range<int>(0, 10);
            var other = new Range<int>(20, 30);
            Assert.IsNull(range.Intersect(other));
        }


        [Test]
        public void Intersect_ShouldReturnIntersection_WhenExists()
        {
            var range = new Range<int>(0, 3);
            var other = new Range<int>(2, 4);
            Assert.AreEqual(new Range<int>(2, 3), range.Intersect(other));
            
        }

        [Test]
        public void ShouldSupportDecimal()
        {
            var range = new Range<decimal>(0.1m, 3.1m);
            var other = new Range<decimal>(2.1m, 4);
            Assert.AreEqual(new Range<decimal>(2.1m, 3.1m), range.Intersect(other));
            
        }
    }
}