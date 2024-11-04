using System;
using System.Collections.Generic;

internal class Program
{
    private static Queue<Person> _people = new Queue<Person>();

    private static void Main(string[] args)
    {
        // Sample data
        InitializeQueue();

        // Process people in the queue
        ProcessQueue();
    }

    private static void InitializeQueue()
    {
        _people.Enqueue(new Person { Name = "Alice", Turns = 2 });
        _people.Enqueue(new Person { Name = "Bob", Turns = 1 });
        _people.Enqueue(new Person { Name = "Charlie", Turns = 0 }); // This person will stay in the queue indefinitely
    }

    private static void ProcessQueue()
    {
        try
        {
            // Process a number of turns or until the queue is empty
            for (int i = 0; i < 5; i++) // Process 5 times for demonstration
            {
                var person = GetNextPerson();
                Console.WriteLine($"{person.Name} has {person.Turns} turns left.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Person GetNextPerson()
    {
        if (_people.Count == 0) // Check if the queue is empty
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue(); // Dequeue the next person

        // Handle turns
        if (person.Turns > 0)
        {
            person.Turns -= 1; // Decrement the turns

            // Enqueue again if they still have turns left after decrementing
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }
        // If Turns is 0, they stay in the queue indefinitely.
        else
        {
            // You can choose to log or handle the situation where a person has 0 turns differently.
            Console.WriteLine($"{person.Name} has no turns left and will remain in the queue.");
            _people.Enqueue(person); // Optional: could choose to remove them instead.
        }

        return person; // Return the processed person
    }
}

internal class Person
{
    public string Name { get; set; }
    public int Turns { get; set; } // Property to hold the number of turns
}
