using System;
using System.Collections.Generic;

namespace Week04Code
{
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
}
