public Person GetNextPerson()
{
    if (_people.IsEmpty())
    {
        throw new InvalidOperationException("No one in the queue.");
    }
    
    Person person = _people.Dequeue();

    // Handle turns: decrement if more than 0; if 0 or less, enqueue again
    if (person.Turns > 0)
    {
        person.Turns -= 1;
        if (person.Turns >= 0) // Enqueue again if still has turns left
        {
            _people.Enqueue(person);
        }
    }
    else
    {
        // If turns is 0 or less, they stay in the queue forever.
        _people.Enqueue(person);
    }

    return person;
}
