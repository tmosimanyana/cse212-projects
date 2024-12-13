using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertTail_Empty()
    {
        var ll = new LinkedList();
        Assert.IsNull(ll.Head);
        Assert.IsNull(ll.Tail);

        ll.InsertTail(1);
        Assert.IsNotNull(ll.Head);
        Assert.IsNotNull(ll.Tail);
        Assert.AreEqual("<LinkedList>{1}", ll.ToString());
    }

    [TestMethod]
    public void InsertTail_Basic()
    {
        var ll = new LinkedList();
        ll.InsertHead(1);
        ll.InsertHead(2);
        ll.InsertTail(3);
        ll.InsertTail(4);
        
        Assert.AreEqual("<LinkedList>{2, 1, 3, 4}", ll.ToString());
    }

    [TestMethod]
    public void Remove_Head()
    {
        var ll = new LinkedList();
        ll.InsertHead(1);
        ll.InsertHead(2);

        ll.Remove(2);  // Removing head node
        Assert.AreEqual("<LinkedList>{1}", ll.ToString());
    }

    [TestMethod]
    public void Remove_Tail()
    {
        var ll = new LinkedList();
        ll.InsertHead(1);
        ll.InsertTail(2);

        ll.Remove(2);  // Removing tail node
        Assert.AreEqual("<LinkedList>{1}", ll.ToString());
    }

    [TestMethod]
    public void Remove_Middle()
    {
        var ll = new LinkedList();
        ll.InsertHead(1);
        ll.InsertTail(2);
        ll.InsertTail(3);

        ll.Remove(2);  // Removing middle node
        Assert.AreEqual("<LinkedList>{1, 3}", ll.ToString());
    }
}
