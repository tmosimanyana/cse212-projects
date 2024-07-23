using System;
using System.Collections.Generic;

namespace Week04Code
{
    public class LinkedList
    {
        private Node head;
        private Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        // Insert a new node at the tail of the list
        public void InsertTail(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        // Insert a new node at the head of the list
        public void InsertHead(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        // Remove the tail node from the list
        public void RemoveTail()
        {
            if (head == null) return;

            if (head.Next == null)
            {
                head = null;
                tail = null;
                return;
            }

            Node current = head;
            while (current.Next != tail)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
        }

        // Remove the first node with the specified data
        public void Remove(int data)
        {
            if (head == null) return;

            if (head.Data == data)
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
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
                if (current.Next == null)
                {
                    tail = current;
                }
            }
        }

        // Replace all occurrences of oldValue with newValue
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

        // Return the list in reverse order
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

        // Insert a new node with newData after the first occurrence of targetData
        public void InsertAfter(int targetData, int newData)
        {
            Node current = head;
            while (current != null && current.Data != targetData)
            {
                current = current.Next;
            }

            if (current != null)
            {
                Node newNode = new Node(newData);
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                {
                    tail = newNode;
                }
            }
        }

        // Return a string representation of the list
        public override string ToString()
        {
            Node current = head;
            List<int> values = new List<int>();
            while (current != null)
            {
                values.Add(current.Data);
                current = current.Next;
            }
            return "<LinkedList>{" + string.Join(", ", values) + "}";
        }

        // Check if both head and tail are not null
        public bool HeadAndTailAreNotNull()
        {
            return head != null && tail != null;
        }

        // Check if both head and tail are null
        public bool HeadAndTailAreNull()
        {
            return head == null && tail == null;
        }
    }

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
}
