public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value == Data)
        {
            // Prevent duplicates; do nothing if the value already exists
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data ensures uniqueness
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data)
            return true; // Found the value

        if (value < Data)
            return Left != null && Left.Contains(value); // Search in the left subtree

        return Right != null && Right.Contains(value); // Search in the right subtree
    }

    // Problem 4: Get the Height of the Tree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Height is 1 + the maximum height of either subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
