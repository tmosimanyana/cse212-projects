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
    private Queue<Person> _queue = new Queue<Person>();

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        // Treat negative or zero turns as "infinite" turns
        if (turns <= 0)
        {
            turns = int.MaxValue; // Use a large number to represent infinite turns
        }
        
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person currentPerson = _queue.Dequeue(); // Get the next person in the queue

        // Decrement their turns (if not infinite)
        if (currentPerson.Turns != int.MaxValue)
        {
            currentPerson.Turns--;

            // If they still have turns left, add them back to the queue
            if (currentPerson.Turns > 0)
            {
                _queue.Enqueue(currentPerson);
            }
        }
        else
        {
            // If the person has infinite turns, simply re-add them to the queue
            _queue.Enqueue(currentPerson);
        }

        return currentPerson;
    }
}
