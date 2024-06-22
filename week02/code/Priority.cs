public class PriorityQueue<T>
{
    private Queue<(T data, int priority)> queue;

    public PriorityQueue()
    {
        queue = new Queue<(T, int)>();
    }

    public void Enqueue(T data, int priority)
    {
        queue.Enqueue((data, priority));
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Error: Queue is empty");
            return default(T);
        }

        (T data, int priority) = default;
        int highestPriority = int.MinValue;

        foreach ((T d, int p) in queue)
        {
            if (p > highestPriority)
            {
                highestPriority = p;
                data = d;
            }
        }

        queue = new Queue<(T, int)>(queue.Where(x => !x.Equals((data, highestPriority))));

        return data;
    }
}
