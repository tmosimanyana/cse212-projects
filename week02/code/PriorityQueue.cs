using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the item with the highest priority.
    /// If multiple items have the same highest priority, the item closest to the front is removed.
    /// </summary>
    /// <returns>The value of the item with the highest priority.</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0) // Check if the queue is empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            // Prioritize items with higher priority or, if equal, those closer to the front (FIFO)
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Retrieve, remove, and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    // Returns the current length of the queue (for testing purposes)
    public int Length => _queue.Count;

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
