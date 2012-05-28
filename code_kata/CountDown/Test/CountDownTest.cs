using NUnit.Framework;

namespace code_kata.CountDown.Test
{
    [TestFixture]
    public class CountDownTest
    {

        [Test]
        public void IsStopped_ShouldReturnTrue_WhenNew()
        {
            var countDown = new CountDown();
            Assert.IsTrue(countDown.IsStopped);
        }

        [Test]
        public void IsStopped_ShouldReturnFalse_AfterStarted()
        {
            var countDown = new CountDown();
            countDown.Start(5);
            Assert.IsFalse(countDown.IsStopped);
            
        }

        [Test]
        public void IsStopped_ShouldReturnTrue_AfterDecreasedMoreTimeThanFirstStarted()
        {
            {
                var countDown = new CountDown();
                countDown.Start(5);
                countDown.Decrease(5);
                Assert.IsTrue(countDown.IsStopped);
            }
            {
                var countDown = new CountDown();
                countDown.Start(5);
                countDown.Decrease(2);
                countDown.Decrease(2);
                countDown.Decrease(2);
                Assert.IsTrue(countDown.IsStopped);
            }
        }

        [Test]
        public void IsStopped_ShouldReturnFalse_AfterDecreasedLessTimeThanFirstStarted()
        {
            var countDown = new CountDown();
            countDown.Start(5);
            countDown.Decrease(4);
            Assert.False(countDown.IsStopped);
        }
    }
}