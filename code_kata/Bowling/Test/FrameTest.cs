using NUnit.Framework;

namespace code_kata.Bowling.Test
{
    [TestFixture]
    public class FrameTest
    {

        [Test]
        public void Down_ShouldReducePinsLeft()
        {
            var game = new Frame();
            game.Throw(5);

            Assert.AreEqual(Frame.TotalPins - 5, game.PinsLeft);
            Assert.AreEqual(5, game.PinsDown);

        }

        [Test]
        public void IsComplete_ShouldReturnTrue_WhenThrowAStrike()
        {
            var game = new Frame();
            game.Throw(10);
            Assert.IsTrue(game.IsComplete);
        }

        [Test]
        public void IsComplete_ShouldReturnTrue_WhenThereAreTwoThrows()
        {
            var game = new Frame();
            game.Throw(1);
            game.Throw(0);
            Assert.IsTrue(game.IsComplete);
        }

        [Test]
        public void IsComplete_ShouldRetrunFalse_WhenThereIsOnyOneThrow_AndIsNotAStrike()
        {
            var game = new Frame();
            game.Throw(1);
            Assert.IsFalse(game.IsComplete);
        }

        [Test]
        public void IsStrike_ShouldRetrunFalse_WhenThereIsOnyOneThrow_AndIsNotAStrike()
        {
            var game = new Frame();
            game.Throw(1);
            Assert.IsFalse(game.IsStrike);
        }

        [Test]
        public void IsStrike_ShouldRetrunFalse_WhenThereAreTwoThrows()
        {
            var game = new Frame();
            game.Throw(1);
            game.Throw(1);
            Assert.IsFalse(game.IsStrike);
        }

        [Test]
        public void IsStrike_ShouldRetrunTrue_WhenThereDownTenPins()
        {
            var game = new Frame();
            game.Throw(10);
            Assert.IsTrue(game.IsStrike);
        }

        [Test]
        public void IsSpare_ShouldReturnTrue_WhenThereAreTwoThrowsTotalOfTenPins()
        {
            var game = new Frame();
            game.Throw(9);
            game.Throw(1);
            Assert.IsTrue(game.IsSpare);
        }

        [Test]
        public void IsSpare_ShouldReturnFalse_WhenThereAreTwoThrowsTotalLessThanTen()
        {
            var game = new Frame();
            game.Throw(1);
            game.Throw(1);
            Assert.IsFalse(game.IsSpare);
        }

        [Test]
        public void IsSpare_ShouldReturnFalse_WhenIsAStrike()
        {
            var game = new Frame();
            game.Throw(10);
            Assert.IsFalse(game.IsSpare);
        }
    }
}