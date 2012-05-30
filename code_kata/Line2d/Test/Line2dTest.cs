using System.Drawing;
using NUnit.Framework;

namespace code_kata.Line2d.Test
{
    [TestFixture]
    public class Line2dTest
    {

        [Test]
        public void ShouldCheckIntersectWithOtherLine()
        {
             var line2D = new Line2d(new Point(2, 3), new Point(4, 5));
             var other = new Line2d(new Point(2, 4), new Point(4, 5));

            Assert.IsTrue(line2D.HasIntersectWith(other));
        }

        [Test]
        public void ShouldCheckNotIntersectWithOtherLine()
        {
            var line2D = new Line2d(new Point(2, 3), new Point(4, 5));
            var other = new Line2d(new Point(2, 4), new Point(4, 6));

            Assert.IsFalse(line2D.HasIntersectWith(other));
        }
    }
}