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
    private List<PriorityQueueItem<T>> queue = new List<PriorityQueueItem<T>>();

    // Enqueue an item with a specific priority
    public void Enqueue(T data, int priority)
    {
        queue.Add(new PriorityQueueItem<T>(data, priority));
    }

    // Dequeue the item with the highest priority, FIFO for ties
    public T Dequeue()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var highestPriorityItem = queue.OrderByDescending(x => x.Priority)
                                        .ThenBy(x => queue.IndexOf(x))
                                        .First();

        queue.Remove(highestPriorityItem);
        return highestPriorityItem.Data;
    }

    public int Length => queue.Count;
}
