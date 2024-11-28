using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YourNamespace.Tests
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        [TestMethod]
        public void TestEnqueueDequeue_SingleElement()
        {
            // Defect(s) Found: Dequeue did not remove the item from the queue.
            // Fix: Corrected Dequeue method to remove the item after returning it.

            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 10);

            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual(0, queue.Length);
        }

        [TestMethod]
        public void TestDequeue_HighestPriority()
        {
            // Defect(s) Found: Dequeue did not always return the highest-priority item.
            // Fix: Ensure the item with the highest priority is always dequeued.

            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 5);
            queue.Enqueue("C", 3);

            Assert.AreEqual("B", queue.Dequeue());
        }

        [TestMethod]
        public void TestDequeue_FIFOTie()
        {
            // Defect(s) Found: FIFO order for same-priority items was not maintained.
            // Fix: Ensure Dequeue returns the first added item among those with the same priority.

            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 5);
            queue.Enqueue("B", 5);
            queue.Enqueue("C", 3);

            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("B", queue.Dequeue());
        }

        [TestMethod]
        public void TestDequeue_EmptyQueue()
        {
            // Defect(s) Found: Dequeue did not throw an exception for an empty queue.
            // Fix: Added exception handling for an empty queue in the Dequeue method.

            var queue = new PriorityQueue<string>();

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void TestLength_Property()
        {
            // Defect(s) Found: Length property did not accurately reflect the number of items.
            // Fix: Correct Length property to count items correctly.

            var queue = new PriorityQueue<string>();
            Assert.AreEqual(0, queue.Length);

            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);

            Assert.AreEqual(2, queue.Length);

            queue.Dequeue();
            Assert.AreEqual(1, queue.Length);
        }

        [TestMethod]
        public void TestDequeue_MultipleItems()
        {
            // Defect(s) Found: Dequeue did not correctly handle multiple items of different priorities.
            // Fix: Ensure Dequeue considers all items and removes the correct one.

            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 5);
            queue.Enqueue("C", 3);

            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("C", queue.Dequeue());
            Assert.AreEqual("A", queue.Dequeue());
        }

        [TestMethod]
        public void TestEnqueue_MultiplePriorities()
        {
            // Defect(s) Found: Enqueue did not correctly add items with various priorities.
            // Fix: Ensure items are added to the queue without altering their priority.

            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 3);

            Assert.AreEqual(3, queue.Length);

            Assert.AreEqual("C", queue.Dequeue()); // Highest priority
            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("A", queue.Dequeue());
        }
    }
}
