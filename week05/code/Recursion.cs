using System;
using System.Collections.Generic;
using System.Linq;

public class Maze
{
    private int[,] _mazeArray;
    public int Width { get; }
    public int Height { get; }

    public Maze(int[,] mazeArray)
    {
        _mazeArray = mazeArray;
        Width = mazeArray.GetLength(1);  // Width corresponds to the number of columns
        Height = mazeArray.GetLength(0); // Height corresponds to the number of rows
    }

    public int this[int x, int y] 
    {
        get => _mazeArray[x, y];
        set => _mazeArray[x, y] = value;
    }

    // Optional methods to retrieve dimensions
    public int GetWidth() => Width;
    public int GetHeight() => Height;
}

public static class Recursion
{
    /// <summary>
    /// Problem 1: Find the sum of squares (1^2 + 2^2 + ... + n^2) recursively.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0) return 0;
        
        // Recursive case: sum the square of n and recurse with n-1
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate permutations of length 'size' from 'letters'.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if size is 0, add the current word to the result
        if (size == 0)
        {
            results.Add(word);
            return;
        }

        // Recursive case: loop through each letter and generate permutations
        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters, size - 1, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Count ways to climb 's' stairs, climbing 1, 2, or 3 stairs at a time.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // If memoization dictionary is null, initialize it
        remember ??= new Dictionary<int, decimal>();

        // If the value is already computed, return from memo
        if (remember.ContainsKey(s)) return remember[s];

        // Solve recursively and store the result in the memo
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// Problem 4: Insert all possible binary strings for a given pattern (with wildcards).
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: if pattern is empty, add an empty string to results
        if (pattern.Length == 0)
        {
            results.Add(string.Empty);
            return;
        }

        // If the first character is a wildcard, branch to both '0' and '1'
        if (pattern[0] == '*')
        {
            // Recurse and add "0" and "1" to each of the returned substrings
            List<string> subResults = new List<string>();
            WildcardBinary(pattern.Substring(1), subResults);
            foreach (var subPattern in subResults)
            {
                results.Add("0" + subPattern);
                results.Add("1" + subPattern);
            }
        }
        else
        {
            // Otherwise, just append the first character and recurse
            List<string> subResults = new List<string>();
            WildcardBinary(pattern.Substring(1), subResults);
            foreach (var subPattern in subResults)
            {
                results.Add(pattern[0] + subPattern);
            }
        }
    }

    /// <summary>
    /// Solve Maze using recursion to insert all paths that start at (0,0) and end at the 'end' square.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need to initialize the currPath list
        if (currPath == null) currPath = new List<ValueTuple<int, int>>();

        // Base case: if out of bounds or hitting a wall (0), return
        if (x < 0 || y < 0 || x >= maze.GetWidth() || y >= maze.GetHeight() || maze[x, y] == 0) return;

        // Add current position to path
        currPath.Add((x, y));

        // If we reached the end (goal), add the path to results
        if (maze[x, y] == 2)
        {
            results.Add(string.Join(" -> ", currPath.Select(p => $"({p.Item1},{p.Item2})")));
            return;
        }

        // Mark the current cell as visited (set to 0)
        maze[x, y] = 0;

        // Move in all four possible directions (down, up, right, left)
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath)); // down
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath)); // up
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath)); // right
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath)); // left

        // Backtrack: unmark the current cell as visited
        maze[x, y] = 1;
    }
}
