using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

public class TakingTurnsQueue
{
    private Queue<Person> queue;

    public TakingTurnsQueue()
    {
        queue = new Queue<Person>();
    }

    // Adds a person to the queue with a given name and turn count.
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        queue.Enqueue(person);
    }

    // Returns the next person in line, re-adding them if they have remaining turns.
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = queue.Dequeue();

        // Handle infinite turns (<= 0 means infinite).
        if (person.Turns <= 0)
        {
            queue.Enqueue(person); // Re-add person with infinite turns to the end of the queue
        }
        else if (person.Turns > 1)
        {
            person.Turns--; // Decrease turns and re-add if more turns are left
            queue.Enqueue(person);
        }
        // If Turns == 1, do not re-add person, as they have no turns left after this

        return person;
    }

    // Property to get the current length of the queue.
    public int Length => queue.Count;
}
