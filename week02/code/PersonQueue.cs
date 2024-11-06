/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue.
    /// </summary>
    /// <param name="person">The person to add.</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the end of the list for FIFO order
    }

    /// <summary>
    /// Remove and return the person at the front of the queue.
    /// </summary>
    /// <returns>The person at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when trying to dequeue from an empty queue.</exception>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty; otherwise, false.</returns>
    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
