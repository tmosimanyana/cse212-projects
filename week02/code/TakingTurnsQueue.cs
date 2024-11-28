using System;
using System.Collections.Generic;

namespace YourNamespace
{
    public class TakingTurnsQueue
    {
        // Queue to hold players and their turn counts.
        private Queue<(string name, int turns)> queue = new();

        // Add a person to the queue.
        public void AddPerson(string name, int turns)
        {
            queue.Enqueue((name, turns));
        }

        // Get the next person in the queue.
        public string GetNextPerson()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            var person = queue.Dequeue();

            // Handle infinite turns (turns == 0).
            if (person.turns == 0 || person.turns > 1)
            {
                // Re-enqueue the person if they have infinite or remaining turns.
                queue.Enqueue((person.name, person.turns > 0 ? person.turns - 1 : person.turns));
            }

            return person.name;
        }

        public int Length => queue.Count;
    }
}
