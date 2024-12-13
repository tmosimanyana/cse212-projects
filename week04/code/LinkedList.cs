public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
        this.Prev = null;
    }
}
