class DoublyLinkedList
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }

    public void AddNode(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail!.Next = newNode; // Set the next of the current tail to the new node
            newNode.Prev = Tail;   // Set the previous of the new node to the current tail
            Tail = newNode;        // Update the tail to the new node
        }
    }

    public void PrintList()
    {
        Node? current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.AddNode(10);
        list.AddNode(20);
        list.AddNode(30);

        list.PrintList(); // Output: 10 20 30
    }
}
