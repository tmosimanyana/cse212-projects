/// <summary>
/// Insert a new node at the back (i.e. the tail) of the linked list.
/// </summary>
public void InsertTail(int value)
{
    // Create a new node
    Node newNode = new(value);

    // If the list is empty, point both head and tail to the new node
    if (_tail is null)
    {
        _head = newNode;
        _tail = newNode;
    }
    // If the list is not empty, adjust the links to add the new node at the end
    else
    {
        _tail.Next = newNode; // Connect the current tail to the new node
        newNode.Prev = _tail; // Connect the new node back to the current tail
        _tail = newNode;      // Update the tail to the new node
    }
}

/// <summary>
/// Remove the last node (i.e. the tail) of the linked list.
/// </summary>
public void RemoveTail()
{
    // If the list is empty, do nothing
    if (_tail is null)
    {
        return;
    }
    // If the list has only one node, set head and tail to null
    else if (_head == _tail)
    {
        _head = null;
        _tail = null;
    }
    // If the list has more than one node, update the tail
    else
    {
        _tail = _tail.Prev; // Move tail to the previous node
        _tail!.Next = null; // Disconnect the last node
    }
}

/// <summary>
/// Remove the first node that contains the specified value.
/// </summary>
public void Remove(int value)
{
    Node? current = _head;

    // Traverse the list to find the node with the value
    while (current is not null)
    {
        if (current.Data == value)
        {
            // If the node is the head, use RemoveHead
            if (current == _head)
            {
                RemoveHead();
            }
            // If the node is the tail, use RemoveTail
            else if (current == _tail)
            {
                RemoveTail();
            }
            // If the node is in the middle, adjust the links
            else
            {
                current.Prev!.Next = current.Next; // Bypass the current node
                current.Next!.Prev = current.Prev;
            }

            return; // Exit after removing the first match
        }

        current = current.Next; // Move to the next node
    }
}

/// <summary>
/// Replace all nodes that contain the oldValue with newValue.
/// </summary>
public void Replace(int oldValue, int newValue)
{
    Node? current = _head;

    // Traverse the list to find all matching nodes
    while (current is not null)
    {
        if (current.Data == oldValue)
        {
            current.Data = newValue; // Replace the value
        }

        current = current.Next; // Move to the next node
    }
}

/// <summary>
/// Iterate backward through the Linked List
/// </summary>
public IEnumerable<int> Reverse()
{
    var current = _tail; // Start at the end since this is a backward iteration.
    while (current is not null)
    {
        yield return current.Data; // Provide (yield) each item to the user
        current = current.Prev; // Go backward in the linked list
    }
}
