using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace
{
    public class PriorityQueue<T>
    {
        // Internal class for queue items.
        private class QueueItem
        {
            public T Value { get; }
            public int Priority { get; }

            public QueueItem(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }

        private List<QueueItem> queue = new();

        // Enqueue a new item with priority.
        public void Enqueue(T value, int priority)
        {
            queue.Add(new QueueItem(value, priority));
        }

        // Dequeue the item with the highest priority (FIFO for ties).
        public T Dequeue()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            var highestPriority = queue.Max(item => item.Priority);
            var itemToDequeue = queue.First(item => item.Priority == highestPriority);

            queue.Remove(itemToDequeue);
            return itemToDequeue.Value;
        }

        public int Length => queue.Count;
    }
}
