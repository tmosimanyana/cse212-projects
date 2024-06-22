using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue;

    public TakingTurnsQueue()
    {
        queue = new Queue<Person>();
    }

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    public void GetNextPerson()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Error: Queue is empty");
            return;
        }

        Person person = queue.Dequeue();
        Console.WriteLine(person.Name);

        if (person.Turns != 1)
        {
            person.DecrementTurn();
            queue.Enqueue(person);
        }
    }
}

public class Person
{
    public string Name { get; }
    public int Turns { get; private set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public void DecrementTurn()
    {
        if (Turns > 0)
            Turns--;
    }

    public override string ToString()
    {
        return $"{Name} ({Turns})";
    }
}
