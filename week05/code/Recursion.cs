public static int SumSquaresRecursive(int n)
{
    if (n <= 0) return 0; // Base case
    return n * n + SumSquaresRecursive(n - 1); // Recursive case
}
