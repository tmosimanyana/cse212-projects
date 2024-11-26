using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<(string Name, int Turns)> queue = new();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue((name, turns));
    }

    public (string Name, int Turns) GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = queue.Dequeue();

        // If infinite turns or more than 1 turn left, re-enqueue the person
        if (person.Turns <= 0 || person.Turns > 1)
        {
            queue.Enqueue((person.Name, person.Turns > 0 ? person.Turns - 1 : person.Turns));
        }

        return person;
    }
}
