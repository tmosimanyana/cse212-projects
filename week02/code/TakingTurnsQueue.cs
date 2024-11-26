using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<(string name, int turns)> queue = new Queue<(string name, int turns)>();

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue((name, turns));
    }

    public string GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = queue.Dequeue();

        // If turns <= 0, infinite turns. Otherwise, decrement turns.
        if (person.turns <= 0 || person.turns > 1)
        {
            queue.Enqueue((person.name, person.turns > 0 ? person.turns - 1 : person.turns));
        }

        return person.name;
    }
}
