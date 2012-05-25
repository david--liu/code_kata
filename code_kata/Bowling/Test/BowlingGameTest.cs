using System;
using NUnit.Framework;

namespace code_kata.Bowling.Test
{
    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void WhenGetScoreOfNewGame_ShouldReturnZero()
        {
            var  game    = new BowlingGame();
            Assert.AreEqual(game.GetScoreOfFrame(1), 0);
        }


        [Test]
        public void ShouldReturnCorrectScoreWhenDoubleStrike()
        {
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).GetScoreOfFrame(1), 25);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).Throw(5).GetScoreOfFrame(1), 25);
        }


       [Test]
        public void ShouldReturnCorrectScore()
        {
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).GetScoreOfFrame(2), 40);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).Throw(4).Throw(5).Throw(5).GetScoreOfFrame(3), 53);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).Throw(4).Throw(5).Throw(5).GetScoreOfFrame(2), 44);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(5).Throw(4).Throw(5).Throw(5).GetScoreOfFrame(4), 63);
        }

        [Test]
        public void ShouldScore300WhenThrowAllStrikesInTenFrames()
        {
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).GetScoreOfFrame(7), 210);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).GetScoreOfFrame(8), 240);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).GetScoreOfFrame(9), 270);
            Assert.AreEqual(new BowlingGame().Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Throw(10).Score, 300);
        }

        [Test]
        public void ShouldScore300WhenThrowAllSparesInTenFrames()
        {
            var game = new BowlingGame().Throw(5).Throw(5)
                .Throw(5).Throw(5) 
                .Throw(5).Throw(5)
                .Throw(5).Throw(5)
                .Throw(5).Throw(5)
                .Throw(5).Throw(5)
                .Throw(5).Throw(5)
                .Throw(5).Throw(5) 
                .Throw(5).Throw(5)
                .Throw(5).Throw(5).Throw(5);

            for (int i = 1; i < 11; i++)
            {
                Assert.AreEqual(game.GetScoreOfFrame(i), i*15);
            }
        }


        [Test]
        public void ShouldScore300WhenThrowAllSplitsInTenFrames()
        {
            var game = new BowlingGame().Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4)
                .Throw(4).Throw(4);

            for (int i = 1; i < 11; i++)
            {
                Assert.AreEqual(game.GetScoreOfFrame(i), i * 8);
            }
        }


        [Test]
        public void ShouldReturnCorrectFramePlaying()
        {
            {
                var game = new BowlingGame();
                Assert.AreEqual(game.Throw(10).Throw(10).FramesPlaying, 3);
            }
            {
                var game = new BowlingGame();
                Assert.AreEqual(game.Throw(1).Throw(1).FramesPlaying, 2);
            }
        }   

       [Test]
       [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldNotAllowThrow()
        {
            var game = new BowlingGame();
            game.Throw(3).Throw(8);
        }   

      
    }
}