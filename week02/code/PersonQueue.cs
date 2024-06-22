using System;
using System.Collections.Generic;

public class PersonQueue {
    private readonly Queue<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Adds a person to the end of the queue.
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person) {
        if (person == null) {
            throw new ArgumentNullException(nameof(person), "Person cannot be null.");
        }
        _queue.Enqueue(person);
    }

    /// <summary>
    /// Removes and returns the person at the front of the queue.
    /// </summary>
    /// <returns>The person at the front of the queue</returns>
    public Person Dequeue() {
        if (_queue.Count == 0) {
            throw new InvalidOperationException("Queue is empty. Cannot dequeue.");
        }
        return _queue.Dequeue();
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty, otherwise false</returns>
    public bool IsEmpty() {
        return _queue.Count == 0;
    }

    public override string ToString() {
        return $"[{string.Join(", ", _queue)}]";
    }
}
