public Person GetNextPerson()
{
    if (_people.IsEmpty())
    {
        throw new InvalidOperationException("No one in the queue.");
    }
    
    Person person = _people.Dequeue();

    // Handle turns: decrement if more than 0; enqueue again if turns are infinite (0 or less)
    if (person.Turns > 0)
    {
        person.Turns -= 1; // Decrement the turns

        // Enqueue again if they still have turns left after decrementing
        if (person.Turns > 0) 
        {
            _people.Enqueue(person);
        }
    }
    // If turns is 0 or less, they stay in the queue forever.
    else
    {
        // In this case, no action is needed since they will stay in the queue
        _people.Enqueue(person); // Optionally, you could remove this line if they should not be enqueued again
    }

    return person;
}
