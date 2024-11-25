public class TakingTurnsQueue
{
    private class Person
    {
        public string Name { get; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }

    private readonly Queue<Person> _queue = new();

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var person = _queue.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns--;
            _queue.Enqueue(person);
        }
        else if (person.Turns == 0) // Infinite turns
        {
            _queue.Enqueue(person);
        }

        return person;
    }

    public int Length => _queue.Count;
}

