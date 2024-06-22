using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue
{
    private List<PriorityItem> queue;

    public PriorityQueue()
    {
        queue = new List<PriorityItem>();
    }

    public void Enqueue(string value, int priority)
    {
        queue.Add(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Error: Queue is empty");
            return null;
        }

        var highestPriorityItem = queue.OrderByDescending(i => i.Priority).ThenBy(i => queue.IndexOf(i)).First();
        queue.Remove(highestPriorityItem);
        return highestPriorityItem.Value;
    }
}

public class PriorityItem
{
    public string Value { get; }
    public int Priority { get; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} ({Priority})";
    }
}
