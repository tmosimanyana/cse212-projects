public static int SumSquaresRecursive(int n)
{
    if (n <= 0)
        return 0;
    return n * n + SumSquaresRecursive(n - 1);
}
