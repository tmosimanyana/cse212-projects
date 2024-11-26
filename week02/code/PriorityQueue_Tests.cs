using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void TestPriorityQueue_BasicPriority()
    {
        var queue = new PriorityQueue<string>();
        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 2);
        queue.Enqueue("High", 3);

        Assert.AreEqual("High", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
        Assert.AreEqual("Low", queue.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var queue = new PriorityQueue<string>();
        queue.Enqueue("First", 3);
        queue.Enqueue("Second", 3);
        queue.Enqueue("Third", 3);

        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Second", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_EmptyQueueException()
    {
        var queue = new PriorityQueue<string>();
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }
}
