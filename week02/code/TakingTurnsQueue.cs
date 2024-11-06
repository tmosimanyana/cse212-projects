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
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = queue.Dequeue();
        
        if (person.Turns > 0)
        {
            person.Turns--;  // Decrease the number of turns if finite
        }

        if (person.Turns >= 0) // Re-enqueue if the person still has turns (including infinite turns)
        {
            queue.Enqueue(person);
        }

        return person;
    }
}

