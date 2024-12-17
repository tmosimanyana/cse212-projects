def SumSquaresRecursive(n):
    # Base case: if n <= 0, return 0
    if n <= 0:
        return 0
    # Recursive case: n^2 + SumSquaresRecursive(n - 1)
    return n**2 + SumSquaresRecursive(n - 1)

# Example usage:
print(SumSquaresRecursive(5))  # Output should be 55 (1^2 + 2^2 + 3^2 + 4^2 + 5^2)
