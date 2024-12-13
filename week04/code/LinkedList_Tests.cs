public class LinkedList
{
    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }

    public void InsertHead(int data)
    {
        var newNode = new Node(data);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
    }

    public void InsertTail(int data)
    {
        var newNode = new Node(data);
        if (Tail == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
    }

    public void RemoveTail()
    {
        if (Tail == null) return;

        if (Head == Tail)
        {
            Head = Tail = null;
        }
        else
        {
            Tail = Tail.Prev;
            Tail.Next = null;
        }
    }

    public void Remove(int data)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    Head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    Tail = current.Prev;

                return;
            }
            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    public IEnumerable<int> Reverse()
    {
        var current = Tail;
        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        var result = "<LinkedList>{";
        var current = Head;
        while (current != null)
        {
            result += current.Data + (current.Next != null ? ", " : "");
            current = current.Next;
        }
        result += "}";
        return result;
    }
}

public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int data)
    {
        this.Data = data;
    }
}
