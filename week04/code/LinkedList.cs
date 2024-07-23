using System;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    public void InsertTail(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void InsertHead(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
    }

    public void RemoveTail()
    {
        if (head == null) return;

        if (head.Next == null)
        {
            head = null;
            return;
        }

        Node current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public void Remove(int data)
    {
        if (head == null) return;

        if (head.Data == data)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data != data)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        Node current = head;
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
        Stack<int> stack = new Stack<int>();
        Node current = head;
        while (current != null)
        {
            stack.Push(current.Data);
            current = current.Next;
        }
        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

public class Program
{
    public static void Main()
    {
        LinkedList list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(3);
        list.PrintList(); // Expected output: 1 -> 2 -> 3 -> null

        list.RemoveTail();
        list.PrintList(); // Expected output: 1 -> 2 -> null

        list.Remove(2);
        list.PrintList(); // Expected output: 1 -> null

        list.InsertHead(2);
        list.InsertHead(2);
        list.Replace(2, 4);
        list.PrintList(); // Expected output: 4 -> 4 -> 1 -> null

        foreach (var item in list.Reverse())
        {
            Console.WriteLine(item); // Expected output: 1 4 4
        }
    }
}
