using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; }
        public int Priority { get; }

        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private readonly List<QueueItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        _queue.Add(new QueueItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var highestPriority = _queue.Max(item => item.Priority);
        var itemToDequeue = _queue.First(item => item.Priority == highestPriority);

        _queue.Remove(itemToDequeue);
        return itemToDequeue.Value;
    }
}
