using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Problem 1
        int n = 5;
        Console.WriteLine($"Sum of squares from 1 to {n}: {Recursion.SumSquaresRecursive(n)}");

        // Problem 2
        List<string> permutations = new List<string>();
        Recursion.PermutationsChoose(permutations, "ABC", 2);
        Console.WriteLine("Permutations of length 2 from 'ABC':");
        permutations.ForEach(Console.WriteLine);

        // Problem 3
        Dictionary<int, int> memo = new Dictionary<int, int>();
        int stairs = 5;
        Console.WriteLine($"Ways to climb {stairs} stairs: {Recursion.CountWaysToClimb(stairs, memo)}");

        // Problem 4
        List<string> patterns = new List<string>();
        Recursion.GenerateBinaryPatterns(patterns, "1*0*");
        Console.WriteLine("Generated binary patterns:");
        patterns.ForEach(Console.WriteLine);

        // Problem 5
        int[,] mazeArray = {
            { 1, 0, 1 },
            { 1, 0, 1 },
            { 1, 1, 2 }
        };
        MazeSolver.Maze maze = new MazeSolver.Maze(mazeArray);
        List<string> paths = new List<string>();
        Recursion.SolveMaze(paths, maze);
        Console.WriteLine("Paths to the end of the maze:");
        paths.ForEach(Console.WriteLine);
    }
}
