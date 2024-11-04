using System;
using System.Collections.Generic;

internal class Program
{
    private static Queue<Person> _people = new Queue<Person>(); // Correctly declare a queue to hold people

    private static void Main(string[] args)
    {
        // Example usage of the queue
        // Add persons to the queue
        _people.Enqueue(new Person { Name = "Alice", Turns = 2 });
        _people.Enqueue(new Person { Name = "Bob", Turns = 1 });
        
        // Process people in the queue
        try
        {
            for (int i = 0; i < 3; i++)
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
            // If Turns is exactly 0 after decrementing, do not enqueue them again.
        }
        else
        {
            // If turns are 0 or less, they stay in the queue forever.
            // This line allows the person to remain in the queue for future processing.
            _people.Enqueue(person);
        }

        return person; // Return the processed person
    }
}

internal class Person
{
    public string Name { get; set; }
    public int Turns { get; set; } // Property to hold the number of turns
}
