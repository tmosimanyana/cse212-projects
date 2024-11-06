using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueueItem<T>
{
    public T Data { get; set; }
    public int Priority { get; set; }

    public PriorityQueueItem(T data, int priority)
    {
        Data = data;
        Priority = priority;
    }
}

public class PriorityQueue<T>
{
    private List<PriorityQueueItem<T>> queue;

    public PriorityQueue()
    {
        queue = new List<PriorityQueueItem<T>>();
    }

    // Adds an item to the queue based on priority
    public void Enqueue(T data, int priority)
    {
        var item = new PriorityQueueItem<T>(data, priority);
        queue.Add(item);
    }

    // Removes and returns the item with the highest priority, following FIFO for ties
    public T Dequeue()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find the item with the highest priority
        int maxPriority = queue.Max(x => x.Priority);
        var item = queue.First(x => x.Priority == maxPriority);
        queue.Remove(item);

        return item.Data;
    }

    // Property to get the current length of the queue
    public int Length => queue.Count;
}
