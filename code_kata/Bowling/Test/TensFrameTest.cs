using System;
using NUnit.Framework;

namespace code_kata.Bowling.Test
{
    [TestFixture]
    public class TensFrameTest
    {
 
        [Test]
        public void ShouldAddThirdThrow_WhenFirstTwoAreStrikes()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(10);
            tensFrame.Throw(10);
            tensFrame.Throw(10);
        }   
        
        [Test]
        public void ShouldAddThirdThrow_WhenFirstOneIsStrike()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(10);
            tensFrame.Throw(9);
            tensFrame.Throw(0);
        }

        [Test]
        public void ShouldAddThirdThrow_WhenFirstTwoIsSpare()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(9);
            tensFrame.Throw(1);
            tensFrame.Throw(10);
        }
        
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldOnlySupportUptoThreeThrows()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(9);
            tensFrame.Throw(1);
            tensFrame.Throw(10);
            tensFrame.Throw(10);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldNotAddThirdThrow_WhenFirstTwoNotSpare()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(1);
            tensFrame.Throw(1);
            tensFrame.Throw(10);
        }


        [Test]
        public void ShouldReturnTheScore()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(9);
            tensFrame.Throw(1);
            Assert.AreEqual(tensFrame.FirstThrow, 9);
            Assert.AreEqual(tensFrame.SecondThrow, 1);
        }

        [Test]
        public void ShouldReturnCompleteWhenThereAreThreeThrows()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(9);
            tensFrame.Throw(1);
            tensFrame.Throw(1);
            Assert.IsTrue(tensFrame.IsComplete);
        }

        [Test]
        public void ShouldReturnCompleteWhenThereAreTwoThrowsAndNotASpare()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(8);
            tensFrame.Throw(1);
            Assert.IsTrue(tensFrame.IsComplete);
        }

        [Test]
        public void ShouldReturnIncompleteWhenThereAreTwoThrowsAndIsASpare()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(8);
            tensFrame.Throw(2);
            Assert.IsFalse(tensFrame.IsComplete);
        }

        [Test]
        public void ShouldReturnIncompleteWhenThereIsOnlyOneThrow()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(8);
            Assert.IsFalse(tensFrame.IsComplete);
        }
        [Test]
        public void ShouldReturnIncompleteWhenThereAreTwoThrowAndThisFirstOneIsAStrike()
        {
            var tensFrame = new TensFrame();
            tensFrame.Throw(10);
            tensFrame.Throw(8);
            Assert.IsFalse(tensFrame.IsComplete);
        }



    }
}