using System.Collections;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    // Insert a new node at the front (i.e. the head) of the linked list.
    public void InsertHead(int value) {
        Node newNode = new Node(value);

        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        } else {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    // Insert a new node at the back (i.e. the tail) of the linked list.
    public void InsertTail(int value) {
        Node newNode = new Node(value);

        if (_tail is null) {
            _head = newNode;
            _tail = newNode;
        } else {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    // Remove the first node (i.e. the head) of the linked list.
    public void RemoveHead() {
        if (_head == _tail) {
            _head = null;
            _tail = null;
        } else if (_head is not null) {
            _head = _head.Next;
            if (_head is not null) {
                _head.Prev = null;
            }
        }
    }

    // Remove the last node (i.e. the tail) of the linked list.
    public void RemoveTail() {
        if (_tail is null) return;

        if (_head == _tail) {
            _head = null;
            _tail = null;
        } else {
            _tail = _tail.Prev;
            if (_tail is not null) {
                _tail.Next = null;
            }
        }
    }

    // Insert 'newValue' after the first occurrence of 'value' in the linked list.
    public void InsertAfter(int value, int newValue) {
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                Node newNode = new Node(newValue);
                newNode.Prev = curr;
                newNode.Next = curr.Next;
                if (curr.Next is not null) {
                    curr.Next.Prev = newNode;
                }
                curr.Next = newNode;

                if (curr == _tail) {
                    _tail = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    // Remove the first node that contains 'value'.
    public void Remove(int value) {
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                if (curr == _head) {
                    RemoveHead();
                } else if (curr == _tail) {
                    RemoveTail();
                } else {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    // Search for all instances of 'oldValue' and replace the value to 'newValue'.
    public void Replace(int oldValue, int newValue) {
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == oldValue) {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    // Yields all values in the linked list
    public IEnumerator<int> GetEnumerator() {
        var curr = _head;
        while (curr is not null) {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    // Iterate backward through the Linked List
    public IEnumerable<int> Reverse() {
        var curr = _tail;
        while (curr is not null) {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}
