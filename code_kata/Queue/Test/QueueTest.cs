using System;
using NUnit.Framework;

namespace code_kata.Queue.Test
{
    [TestFixture]
    public class QueueTest
    {

        [Test]
        public void ShouldEnqueueAndDequeue()
        {
            var queue = new MyQueue<string>();
            var expected = "abc";
            queue.Enqueue(expected);
            Assert.AreEqual(expected, queue.Dequeue());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_ShouldThrowInvalidOperationExceptionWhenTheQueueIsEmpty()
        {
            var queue = new MyQueue<string>();
            queue.Dequeue();
        }

        [Test]
        public void ShouldReturnQueueCount()
        {
            var queue = new MyQueue<string>();
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue("abc");
            queue.Enqueue("abc");
            Assert.AreEqual(2, queue.Count);
        }


        [Test]
        public void ShouldBeFIFO()
        {
            var queue = new MyQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            queue.Enqueue("third");

            Assert.AreEqual("first", queue.Dequeue());
            Assert.AreEqual("second", queue.Dequeue());
            Assert.AreEqual("third", queue.Dequeue());
        }
    }
}