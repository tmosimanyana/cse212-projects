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
