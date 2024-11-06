using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with varying priorities
    // Expected Result: Items with higher priorities should be dequeued first
    // Defect(s) Found: None after correction
    public void TestPriorityQueue_BasicPriority()
    {
        var queue = new PriorityQueue<string>();

        queue.Enqueue("Low Priority", 1);
        queue.Enqueue("Medium Priority", 2);
        queue.Enqueue("High Priority", 3);

        Assert.AreEqual("High Priority", queue.Dequeue());
        Assert.AreEqual("Medium Priority", queue.Dequeue());
        Assert.AreEqual("Low Priority", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority, testing FIFO for same-priority items
    // Expected Result: Items with the same priority should be dequeued in FIFO order
    // Defect(s) Found: None after correction
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var queue = new PriorityQueue<string>();

        queue.Enqueue("First High Priority", 3);
        queue.Enqueue("Second High Priority", 3);
        queue.Enqueue("Third High Priority", 3);

        Assert.AreEqual("First High Priority", queue.Dequeue());
        Assert.AreEqual("Second High Priority", queue.Dequeue());
        Assert.AreEqual("Third High Priority", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: InvalidOperationException should be thrown with "The queue is empty." message
    // Defect(s) Found: None after correction
    public void TestPriorityQueue_EmptyQueueException()
    {
        var queue = new PriorityQueue<string>();

        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with FIFO order for ties
    // Expected Result: High priority items are dequeued first, and items with same priority follow FIFO
    // Defect(s) Found: None after correction
    public void TestPriorityQueue_MixedPrioritiesAndFIFO()
    {
        var queue = new PriorityQueue<string>();

        queue.Enqueue("Medium Priority 1", 2);
        queue.Enqueue("High Priority", 3);
        queue.Enqueue("Medium Priority 2", 2);
        queue.Enqueue("Low Priority", 1);

        Assert.AreEqual("High Priority", queue.Dequeue());
        Assert.AreEqual("Medium Priority 1", queue.Dequeue());
        Assert.AreEqual("Medium Priority 2", queue.Dequeue());
        Assert.AreEqual("Low Priority", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it
    // Expected Result: The item should be dequeued correctly
    // Defect(s) Found: None after correction
    public void TestPriorityQueue_SingleItem()
    {
        var queue = new PriorityQueue<string>();

        queue.Enqueue("Only Item", 1);

        Assert.AreEqual("Only Item", queue.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }
}
