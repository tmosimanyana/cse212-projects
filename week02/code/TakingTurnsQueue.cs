using System;
using System.Collections.Generic;

public class Person
{
    // Properties to hold the name and number of turns for a person
    public string Name { get; set; }
    public int Turns { get; set; }

    // Constructor to initialize the person's name and turns
    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns; // Initialize the turns for this person
    }
}

public class TakingTurnsQueue
{
    // Queue to manage the persons in line
    private Queue<Person> _queue = new Queue<Person>();

    // Property to get the number of persons currently in the queue
    public int Length => _queue.Count;

    // Method to add a person to the queue
    public void AddPerson(string name, int turns)
    {
        // Treat negative or zero turns as "infinite" turns
        if (turns <= 0)
        {
            turns = int.MaxValue; // Use a large number to represent infinite turns
        }
        
        _queue.Enqueue(new Person(name, turns)); // Enqueue the new person
    }

    // Method to get the next person in line
    public Person GetNextPerson()
    {
        if (_queue.Count == 0) // Check if the queue is empty
        {
            throw new InvalidOperationException("No one in the queue."); // Handle empty queue case
        }

        Person currentPerson = _queue.Dequeue(); // Dequeue the next person

        // Decrement their turns (if not infinite)
        if (currentPerson.Turns != int.MaxValue)
        {
            currentPerson.Turns--; // Decrease the turn count

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

        return currentPerson; // Return the processed person
    }
}

class Program
{
    static void Main(string[] args)
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 2);
        queue.AddPerson("Bob", 5);
        queue.AddPerson("Charlie", 0); // Charlie has infinite turns

        // Process the queue until it's empty
        while (queue.Length > 0)
        {
            var person = queue.GetNextPerson();
            Console.WriteLine($"{person.Name} has {person.Turns} turns left.");
        }
    }
}
