public void InsertTail(int value)
{
    Node newNode = new(value);
    if (_tail is null)
    {
        _head = newNode;
        _tail = newNode;
    }
    else
    {
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }
}
