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

    /// <summary>
    /// Insert a new node at the end of the linked list.
    /// </summary>
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

    /// <summary>
    /// Remove the last node in the linked list.
    /// </summary>
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

    /// <summary>
    /// Replace all occurrences of oldValue with newValue.
    /// </summary>
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

    /// <summary>
    /// Iterate backward through the linked list.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? current = _tail;

        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    /// <summary>
    /// Insert a new node after a specific node.
    /// </summary>
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

        // If the node was the tail, update the tail
        if (node == _tail)
        {
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node in the linked list.
    /// </summary>
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

    /// <summary>
    /// Iterate forward through the linked list.
    /// </summary>
    public IEnumerable<int> GetEnumerator()
    {
        Node? current = _head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Overload example for addition operator
    public static LinkedList operator +(LinkedList list, int value)
    {
        list.InsertTail(value);
        return list;
    }

    // Overload example for equality operator
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

        return current1 == null && current2 == null; // Both should be null to be equal
    }

    public static bool operator !=(LinkedList list1, LinkedList list2)
    {
        return !(list1 == list2); // Negation of equality operator
    }

    // Overload comparison operators
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

    // Helper method to calculate the sum of elements in the list
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

    // Ensure proper equality check (needed for == and != operators to work correctly)
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
