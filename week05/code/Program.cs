using System;
using System.Collections.Generic;
using MazeSolver;
using RecursionSolver;

class Program
{
    static void Main(string[] args)
    {
        // Example Maze (1 = free path, 0 = wall, 2 = goal)
        int[,] mazeArray = new int[,] {
            { 1, 1, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 2 },
        };

        // Create a maze object
        MazeSolver.Maze maze = new MazeSolver.Maze(mazeArray);
        
        // Solve the maze recursively and collect results
        List<string> paths = new List<string>();
        RecursionSolver.Recursion.SolveMaze(paths, maze);

        // Print all possible paths
        Console.WriteLine("Possible paths:");
        foreach (var path in paths)
        {
            Console.WriteLine(path);
        }

        // Example recursive problem: Sum of squares
        int n = 5;
        int sum = RecursionSolver.Recursion.SumSquaresRecursive(n);
        Console.WriteLine($"Sum of squares from 1 to {n}: {sum}");

        // Example recursive problem: Permutations
        List<string> permutations = new List<string>();
        RecursionSolver.Recursion.PermutationsChoose(permutations, "abc", 2);
        Console.WriteLine("Permutations of length 2 from 'abc':");
        foreach (var perm in permutations)
        {
            Console.WriteLine(perm);
        }

        // Example recursive problem: Ways to climb stairs
        int stairs = 5;
        decimal ways = RecursionSolver.Recursion.CountWaysToClimb(stairs);
        Console.WriteLine($"Ways to climb {stairs} stairs: {ways}");

        // Example recursive problem: Wildcard binary pattern
        List<string> wildcardResults = new List<string>();
        RecursionSolver.Recursion.WildcardBinary("1*0*", wildcardResults);
        Console.WriteLine("Wildcard binary strings for '1*0*':");
        foreach (var result in wildcardResults)
        {
            Console.WriteLine(result);
        }
    }
}
