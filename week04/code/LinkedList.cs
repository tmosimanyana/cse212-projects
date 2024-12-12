using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedList : IEnumerable<int>
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    // Insert at the head of the list
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
    }

    // Problem 1: Insert at the tail of the list
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Problem 2: Remove the tail node
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

    // Problem 3: Remove the first node with a specific value
    public void Remove(int value)
    {
        if (head == null) return;

        if (head.Value == value)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    // Insert after a specific value
    public void InsertAfter(int target, int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == target)
            {
                Node newNode = new Node(value);
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }

    // Problem 4: Replace all occurrences of oldValue with newValue
    public void Replace(int oldValue, int newValue)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == oldValue)
            {
                current.Value = newValue;
            }
            current = current.Next;
        }
    }

    // Problem 5: Reversed iterator
    public IEnumerable<int> Reverse()
    {
        Stack<int> stack = new Stack<int>();
        Node current = head;

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }

        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }

    // Check if both head and tail are null (used in tests)
    public bool HeadAndTailAreNull()
    {
        return head == null;
    }

    // Check if both head and tail are not null (used in tests)
    public bool HeadAndTailAreNotNull()
    {
        return head != null;
    }

    // Convert the list to string format "<LinkedList>{value1, value2, ...}"
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<LinkedList>{");

        Node current = head;
        while (current != null)
        {
            sb.Append(current.Value);
            if (current.Next != null)
            {
                sb.Append(", ");
            }
            current = current.Next;
        }

        sb.Append("}");
        return sb.ToString();
    }

    // Implement IEnumerable for iteration
    public IEnumerator<int> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Extension method for IEnumerable<int> to convert to string format "<IEnumerable>{value1, value2, ...}"
public static class IEnumerableExtensions
{
    public static string AsString(this IEnumerable<int> enumerable)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<IEnumerable>{");

        bool first = true;
        foreach (var item in enumerable)
        {
            if (!first)
            {
                sb.Append(", ");
            }
            sb.Append(item);
            first = false;
        }

        sb.Append("}");
        return sb.ToString();
    }
}
