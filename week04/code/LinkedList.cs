using System;
using System.Collections.Generic;

public class LinkedList
{
    // Node class to represent each element in the linked list
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

    private Node? _head; // Head of the linked list
    private Node? _tail; // Tail of the linked list

    // Constructor to initialize an empty linked list
    public LinkedList()
    {
        _head = null;
        _tail = null;
    }

    // Method to insert a new node at the end of the linked list
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

    // Method to remove the last node in the linked list
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

    // Method to replace all occurrences of oldValue with newValue
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

    // Method to iterate backward through the linked list
    public IEnumerable<int> Reverse()
    {
        Node? current = _tail;

        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    // Method to insert a new node after a specific node
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

    // Method to remove the first node in the linked list
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

    // Method to iterate forward through the linked list
    public IEnumerable<int> GetEnumerator()
    {
        Node? current = _head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Overload for addition operator to insert a value at the tail
    public static LinkedList operator +(LinkedList list, int value)
    {
        list.InsertTail(value);
        return list;
    }

    // Overload for equality operator to check if two lists are equal
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

    // Overload for inequality operator to check if two lists are not equal
    public static bool operator !=(LinkedList list1, LinkedList list2)
    {
        return !(list1 == list2); // Negation of equality operator
    }

    // Overload for greater-than comparison based on sum of elements
    public static bool operator >(LinkedList list1, LinkedList list2)
    {
        int sum1 = list1.GetSum();
        int sum2 = list2.GetSum();
        return sum1 > sum2;
    }

    // Overload for less-than comparison based on sum of elements
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

    // Ensure proper equality check for == and != operators
    public override bool Equals(object? obj)
    {
        if (obj is LinkedList other)
        {
            return this == other;
        }
        return false;
    }

    // Override GetHashCode for proper hash-based operations
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
