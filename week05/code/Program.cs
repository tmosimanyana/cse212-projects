using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Problem 1: Sum of squares
        int n = 5;
        int sum = RecursionSolver.Recursion.SumSquaresRecursive(n);
        Console.WriteLine($"Sum of squares from 1 to {n}: {sum}");

        // Problem 2: Permutations
        List<string> permutations = new List<string>();
        RecursionSolver.Recursion.PermutationsChoose(permutations, "abc", 2);
        Console.WriteLine("Permutations of length 2 from 'abc':");
        foreach (var perm in permutations)
        {
            Console.WriteLine(perm);
        }

        // Problem 3: Counting ways to climb stairs
        var memo = new Dictionary<int, int>();
        int stairs = 5;
        int ways = RecursionSolver.Recursion.CountWaysToClimb(stairs, memo);
        Console.WriteLine($"Ways to climb {stairs} stairs: {ways}");

        // Problem 4: Wildcard binary patterns
        List<string> binaryPatterns = new List<string>();
        RecursionSolver.Recursion.WildcardBinaryPatterns(binaryPatterns, "1*1");
        Console.WriteLine("Binary patterns for '1*1':");
        foreach (var pattern in binaryPatterns)
        {
            Console.WriteLine(pattern);
        }
    }
}
