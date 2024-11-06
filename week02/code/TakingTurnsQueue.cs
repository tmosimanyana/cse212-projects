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

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}

public class TakingTurnsQueue
{
    private Queue<Person> queue;

    public TakingTurnsQueue()
    {
        queue = new Queue<Person>();
    }

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var person = queue.Dequeue();

        // If they still have turns or infinite turns, re-enqueue them.
        if (person.Turns > 0)
        {
            person.Turns--;
            queue.Enqueue(person);
        }
        else if (person.Turns <= 0)
        {
            // They have infinite turns, re-enqueue without modifying turns.
            queue.Enqueue(person);
        }

        return person;
    }

    public int Length => queue.Count;
}
