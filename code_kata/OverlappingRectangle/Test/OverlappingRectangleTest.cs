using NUnit.Framework;

namespace code_kata.OverlappingRectangle.Test
{
    [TestFixture]
    public class OverlappingRectangleTest
    {

        [Test]
        public void ShouldComputeAreaAndCircumference()
        {
            int x1 = 2;
            int y1 = 2;
            int x2 = 4;
            int y2 = 4;
            var rectangle = new OverlappingRectangle(x1, y1, x2, y2);
            Assert.AreEqual((4 - 2) * (4 - 2), rectangle.Area);
            Assert.AreEqual(((4 - 2) + (4 - 2)) * 2, rectangle.Circumference);
        }

        [Test]
        public void ComputeAreaAndCircumference_ShouldAlwaysReturnPositiveNumbers()
        {
            int x1 = 4;
            int y1 = 4;
            int x2 = 2;
            int y2 = 2;
            var rectangle = new OverlappingRectangle(x1, y1, x2, y2);
            Assert.AreEqual((4 - 2) * (4 - 2), rectangle.Area);
            Assert.AreEqual(((4 - 2) + (4 - 2)) * 2, rectangle.Circumference);
        }

        [Test]
        public void ShouldReturnMinAndMaxXY()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            Assert.AreEqual(1, rectangle1.MinX);
            Assert.AreEqual(1, rectangle1.MinY);
            Assert.AreEqual(3, rectangle1.MaxX);
            Assert.AreEqual(3, rectangle1.MaxY);

            var rectangle2 = new OverlappingRectangle(1, 1, -3, -3);
            Assert.AreEqual(-3, rectangle2.MinX);
            Assert.AreEqual(-3, rectangle2.MinY);
            Assert.AreEqual(1, rectangle2.MaxX);
            Assert.AreEqual(1, rectangle2.MaxY);
        }

        [Test]
        public void IsAnyOfTheCornerPointsWithInOf_ShouldReturnTrue_WhenAnyOfTheOtherFourCornerPoingsIsInsideOfTheArea()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            var rectangle2 = new OverlappingRectangle(2, 2, 3, 3);
            var rectangle3 = new OverlappingRectangle(0, 0, 2, 2);
            var rectangle4 = new OverlappingRectangle(0, 4, 2, 2);
            var rectangle5 = new OverlappingRectangle(4, 0, 2, 2);

            Assert.IsTrue(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle2));
            Assert.IsTrue(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle3));
            Assert.IsTrue(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle4));
            Assert.IsTrue(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle5));
            
        }
        
        [Test]
        public void IsAnyOfTheCornerPointsWithInOf_ShouldReturnFalse_WhenAllOfTheOtherFourCornerPoingsIsNotInsideOfTheArea()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            var rectangle2 = new OverlappingRectangle( -1, -1, 0, 0);
            var rectangle3 = new OverlappingRectangle(0, -2, 0, 3);
            var rectangle4 = new OverlappingRectangle(0, 4, -1, 0);
            var rectangle5 = new OverlappingRectangle(4, 0, 5, 4);

            Assert.IsFalse(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle2));
            Assert.IsFalse(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle3));
            Assert.IsFalse(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle4));
            Assert.IsFalse(rectangle1.IsAnyOfTheCornerPointsWithIn(rectangle5));
            
        }

        [Test]
        public void IsOverlappedWith_ShouldReturnFalse_WhenTwoRectanglesNotOverlap()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            var rectangle2 = new OverlappingRectangle(5, 5, 6, 6);
            var rectangle3 = new OverlappingRectangle(-1, -1, 0, 0);
            var rectangle4 = new OverlappingRectangle(-1, 1, 0, 0);
            var rectangle5 = new OverlappingRectangle(1, -1, 0, 0);

            Assert.IsFalse(rectangle1.IsOverlappedWith(rectangle2));
            Assert.IsFalse(rectangle1.IsOverlappedWith(rectangle3));
            Assert.IsFalse(rectangle1.IsOverlappedWith(rectangle4));
            Assert.IsFalse(rectangle1.IsOverlappedWith(rectangle5));
            
        }

       [Test]
        public void IsOverlappedWith_ShouldReturnFalse_WhenTheOtherRectanglesContainsThis()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            var rectangle2 = new OverlappingRectangle(0, 0, 6, 6);

            Assert.IsTrue(rectangle1.IsOverlappedWith(rectangle2));
        }


       [Test]
        public void IsOverlappedWith_ShouldReturnFalse_WhenThisContainsTheOtherRectangle()
        {
            var rectangle1 = new OverlappingRectangle(1, 1, 3, 3);
            var rectangle2 = new OverlappingRectangle(2, 2, 3, 3);

            Assert.IsTrue(rectangle1.IsOverlappedWith(rectangle2));
        }


    }
}