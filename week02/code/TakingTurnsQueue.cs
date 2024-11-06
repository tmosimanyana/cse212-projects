using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    // Add person to the queue
    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    // Get the next person from the queue and update their turn count
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var person = queue.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns--;
            queue.Enqueue(person); // Re-enqueue if they still have turns left
        }

        return person;
    }
}
