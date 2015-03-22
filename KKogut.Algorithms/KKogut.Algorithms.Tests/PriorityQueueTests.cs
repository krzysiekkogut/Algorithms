using System;
using KKogut.PriorityQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void AddItemToPriorityQueue()
        {
            var q = new PriorityQueue<int>(10);
            
            q.Enqueue(5);

            Assert.AreEqual(1, q.Count);
        }

        [TestMethod]
        public void RemoveItemFromPriorityQueue()
        {
            var q = new PriorityQueue<int>(10);
            q.Enqueue(5);
            
            var x = q.Dequeue();

            Assert.AreEqual(5, x);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cannot enqueue more elements than queue size.")]
        public void CanInsertOnlyUpToQueueSize()
        {
            var q = new PriorityQueue<int>(2);
            q.Enqueue(5);
            q.Enqueue(7);
            q.Enqueue(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No elements in queue.")]
        public void CanRemoveOnlyHowMuchWasInQueue()
        {
            var q = new PriorityQueue<int>(2);
            q.Enqueue(5);
            q.Dequeue();
            q.Dequeue();
        }

        [TestMethod]
        public void GetMin()
        {
            var q = new PriorityQueue<int>(5);
            q.Enqueue(5);
            q.Enqueue(2);
            q.Enqueue(7);

            var x = q.Min;

            Assert.AreEqual(2, x);
        }

        [TestMethod]
        public void DequeeInCorrectOrder()
        {
            var q = new PriorityQueue<int>(8);
            q.Enqueue(5);
            q.Enqueue(2);
            q.Enqueue(1);
            q.Enqueue(3);
            q.Enqueue(7);
            q.Enqueue(10);
            q.Enqueue(6);
            var expected = new int[] { 1, 2, 3, 5, 6, 7, 10 };

            var actual = new int[7];
            for (int i = 0; i < 7; i++)
                actual[i] = q.Dequeue();

            for (int i = 0; i < 7; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
