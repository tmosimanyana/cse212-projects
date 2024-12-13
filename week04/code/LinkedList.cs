using System;
using System.Collections.Generic;

public class LinkedList
{
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node? _head;
    private Node? _tail;

    public LinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public void RemoveTail()
    {
        if (_tail == null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;

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
        Node? current = _tail;

        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public void InsertAfter(Node? node, int value)
    {
        if (node == null) return;

        Node newNode = new(value);
        newNode.Next = node.Next;
        newNode.Prev = node;

        if (node.Next != null)
        {
            node.Next.Prev = newNode;
        }

        node.Next = newNode;

        if (node == _tail)
        {
            _tail = newNode;
        }
    }

    public void RemoveHead()
    {
        if (_head == null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
    }

    public LinkedListEnumerator GetEnumerator()
    {
        return new LinkedListEnumerator(_head);
    }

    public class LinkedListEnumerator : IEnumerator<int>
    {
        private Node? _currentNode;
        
        public LinkedListEnumerator(Node? head)
        {
            _currentNode = head;
        }

        public int Current => _currentNode?.Data ?? throw new InvalidOperationException();

        object? System.Collections.IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_currentNode == null) return false;

            _currentNode = _currentNode.Next;
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = null;
        }

        public void Dispose() { }
    }

    public static LinkedList operator +(LinkedList list, int value)
    {
        list.InsertTail(value);
        return list;
    }

    public static bool operator ==(LinkedList list1, LinkedList list2)
    {
        Node? current1 = list1._head;
        Node? current2 = list2._head;

        while (current1 != null && current2 != null)
        {
            if (current1.Data != current2.Data) return false;

            current1 = current1.Next;
            current2 = current2.Next;
        }

        return current1 == null && current2 == null;
    }

    public static bool operator !=(LinkedList list1, LinkedList list2)
    {
        return !(list1 == list2);
    }

    public static bool operator >(LinkedList list1, LinkedList list2)
    {
        int sum1 = list1.GetSum();
        int sum2 = list2.GetSum();
        return sum1 > sum2;
    }

    public static bool operator <(LinkedList list1, LinkedList list2)
    {
        int sum1 = list1.GetSum();
        int sum2 = list2.GetSum();
        return sum1 < sum2;
    }

    private int GetSum()
    {
        int sum = 0;
        Node? current = _head;

        while (current != null)
        {
            sum += current.Data;
            current = current.Next;
        }

        return sum;
    }

    public override bool Equals(object? obj)
    {
        if (obj is LinkedList other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hashCode = 0;
        Node? current = _head;

        while (current != null)
        {
            hashCode = (hashCode * 31) + current.Data;
            current = current.Next;
        }

        return hashCode;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();

        linkedList += 10;  // Adds 10 to the list
        linkedList += 20;  // Adds 20 to the list
        linkedList += 30;  // Adds 30 to the list

        Console.WriteLine("Forward iteration:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        linkedList.Replace(20, 25);
        Console.WriteLine("\nAfter replacing 20 with 25:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nBackward iteration:");
        foreach (var item in linkedList.Reverse())
        {
            Console.WriteLine(item);
        }

        linkedList.RemoveTail();
        Console.WriteLine("\nAfter removing the tail:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        linkedList.RemoveHead();
        Console.WriteLine("\nAfter removing the head:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }
    }
}
