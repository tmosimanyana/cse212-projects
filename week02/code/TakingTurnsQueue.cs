using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    // Property to get the current length of the queue
    public int Length => queue.Count;

    // Adds a person to the queue
    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    // Gets the next person in line based on turns
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var person = queue.Dequeue();  // Get the next person in line

        if (person.Turns > 0)
        {
            person.Turns--;  // Decrease turns if it's finite
            queue.Enqueue(person);  // Put them back in the queue if they still have turns left
        }
        else
        {
            queue.Enqueue(person);  // Re-enqueue if they have infinite turns
        }

        return person;
    }
}
