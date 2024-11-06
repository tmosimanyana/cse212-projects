using System.Diagnostics;

public class TakingTurnsQueue
{
    private Queue<Person> queue;

    public TakingTurnsQueue()
    {
        queue = new Queue<Person>();
    }

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        Debug.WriteLine($"Added {person.Name} with {person.Turns} turns.");
        queue.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = queue.Dequeue();
        Debug.WriteLine($"Processing {person.Name} with {person.Turns} turns.");

        if (person.Turns <= 0)
        {
            queue.Enqueue(person);
            Debug.WriteLine($"{person.Name} has infinite turns, re-added to queue.");
        }
        else if (person.Turns > 1)
        {
            person.Turns--;
            queue.Enqueue(person);
            Debug.WriteLine($"{person.Name} has {person.Turns} turns remaining, re-added to queue.");
        }
        else
        {
            Debug.WriteLine($"{person.Name} has no remaining turns, not re-added.");
        }

        return person;
    }

    public int Length => queue.Count;
}
