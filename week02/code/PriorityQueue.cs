namespace YourNamespace
{
    public class PriorityQueue<T>
    {
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

        public void Enqueue(T value, int priority)
        {
            queue.Add(new QueueItem(value, priority));
        }

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
