using System;
using System.Collections.Generic;

public class LinkedList
{
    private class Node
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
    /// Check if both head and tail are null.
    /// </summary>
    public bool HeadAndTailAreNull() => _head == null && _tail == null;

    /// <summary>
    /// Check if both head and tail are not null.
    /// </summary>
    public bool HeadAndTailAreNotNull() => _head != null && _tail != null;

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
    /// Remove the first node with the specified value.
    /// </summary>
    public void Remove(int value)
    {
        Node? current = _head;

        while (current != null)
        {
            if (current.Data == value)
            {
                if (current == _head) RemoveHead();
                else if (current == _tail) RemoveTail();
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }

                return;
            }

            current = current.Next;
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
    public void InsertAfter(Node node, int value)
    {
        Node newNode = new(value);

        newNode.Next = node.Next;
        newNode.Prev = node;

        if (node.Next != null)
        {
            node.Next.Prev = newNode;
        }

        node.Next = newNode;

        if (_tail == node)
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
}
