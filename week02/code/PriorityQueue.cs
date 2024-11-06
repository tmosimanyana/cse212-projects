public string Dequeue()
{
    if (_queue.Count == 0) // Check if the queue is empty
    {
        throw new InvalidOperationException("The queue is empty.");
    }

    // Find the index of the item with the highest priority (FIFO for items with the same priority)
    int highPriorityIndex = 0;
    for (int index = 1; index < _queue.Count; index++)
    {
        // Prioritize items with higher priority, retain first occurrence in case of tie
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
