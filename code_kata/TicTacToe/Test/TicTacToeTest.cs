using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace code_kata.TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeTest
    {
        [Test]
        public void ShouldStartNew()
        {
            var game = new TicTacToe();
            Assert.IsTrue(game.IsNew);

            game.Mark(1,1);

            Assert.IsFalse(game.IsNew);

            game.StartNew();

            Assert.IsTrue(game.IsNew);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void Mark_ShouldWitnIn3X3()
        {
            var game = new TicTacToe();
            Assert.IsFalse(game.CanMark(4, 0));
            game.Mark(4, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ShouldNotMarkTheSameStep()
        {
            var game = new TicTacToe();
            game.Mark(1, 1);

            Assert.IsFalse(game.CanMark(1, 1));
            game.Mark(1, 1);
        }

        [Test]
        public void ShouldPrintGame()
        {
            var printMessage = MockRepository.GenerateStub<IPrintMessage>();
            var game = new TicTacToe(printMessage);
            game.Mark(1, 1);
            game.Mark(2, 2);
            game.Mark(3, 3);

            game.Print("|");

            printMessage.AssertWasCalled(x => x.Print("X| | \n |O| \n | |X"));


        }

        [Test]
        public void ShouldCheckIsWinner()
        {
            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(2, 1); //O
                game.Mark(1, 2); //X
                game.Mark(2, 2); //O
                game.Mark(1, 3); //X

                Assert.IsTrue(game.IsWinner("X"));
            }
            
            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(1, 2); //O
                game.Mark(2, 2); //X
                game.Mark(2, 3); //O
                game.Mark(3, 3); //X

                Assert.IsTrue(game.IsWinner("X"));
            }
            
            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(1, 2); //O
                game.Mark(2, 3); //X
                game.Mark(2, 2); //O
                game.Mark(3, 3); //X
                game.Mark(3, 2); //O

                Assert.IsTrue(game.IsWinner("O"));
            }
        }

        [Test]
        public void ShouldCheckIfTheGameIsOver()
        {
            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(1, 2); //O
                game.Mark(2, 2); //X
                game.Mark(2, 3); //O
                game.Mark(3, 3); //X

                Assert.IsTrue(game.IsGameOver());
            }

            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(2, 1); //O
                game.Mark(3, 1); //X
                game.Mark(2, 2); //O
                game.Mark(1, 2); //X
                game.Mark(3, 2); //O
                game.Mark(2, 3); //X
                game.Mark(1, 3); //O
                game.Mark(3, 3); //O

                Assert.IsTrue(game.IsGameOver());
                Assert.IsTrue(game.IsGameDraw());
            }
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void Mark_ShouldNotAllowedWithTheGameIsOver()
        {
            {
                var game = new TicTacToe();
                game.Mark(1, 1); //X
                game.Mark(1, 2); //O
                game.Mark(2, 2); //X
                game.Mark(2, 3); //O
                game.Mark(3, 3); //X
                game.Mark(3, 1); //O

                Assert.IsTrue(game.IsGameOver());
                Assert.IsFalse(game.CanMark(3, 2));
                game.Mark(3, 2);
            }
        }

        
    }
}