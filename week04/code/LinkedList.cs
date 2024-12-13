public class LinkedList
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }

    // Insert a node at the tail of the list
    public void InsertTail(int data)
    {
        // Create the new node
        Node newNode = new Node(data);

        // If the list is empty, set both Head and Tail to the new node
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            // Otherwise, find the current tail and update it
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
    }

    // For debugging and testing purposes, override ToString method
    public override string ToString()
    {
        Node? current = Head;
        List<int> values = new List<int>();

        while (current != null)
        {
            values.Add(current.Data);
            current = current.Next;
        }

        return $"<LinkedList>{{{string.Join(", ", values)}}}";
    }
}


