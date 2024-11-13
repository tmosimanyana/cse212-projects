public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Insert unique values only (Problem 1)
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If the value is equal to Data, do nothing to ensure unique values (sorted set)
    }

    public bool Contains(int value)
    {
        // Problem 2: Recursively check if the value is in the tree
        if (value < Data)
            return Left?.Contains(value) ?? false;
        if (value > Data)
            return Right?.Contains(value) ?? false;
        return true;  // The value matches the node
    }

    public int GetHeight()
    {
        // Problem 4: Get the height of the node in the tree
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
