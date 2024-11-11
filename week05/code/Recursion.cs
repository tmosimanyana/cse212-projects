using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0) return 0;
        // Recursive case: sum the square of n and recurse with n-1
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
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
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  
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
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
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
            WildcardBinary(pattern.Substring(1), results).ForEach(subPattern => results.Add("0" + subPattern));
            WildcardBinary(pattern.Substring(1), results).ForEach(subPattern => results.Add("1" + subPattern));
        }
        else
        {
            // Otherwise, just append the first character and recurse
            WildcardBinary(pattern.Substring(1), results).ForEach(subPattern => results.Add(pattern[0] + subPattern));
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
        if (x < 0 || y < 0 || x >= maze.Width || y >= maze.Height || maze[x, y] == 0) return;

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

public class Maze
{
    public int Width { get; set; }
    public int Height { get; set; }
    private int[,] grid;

    public Maze(int width, int height)
    {
        Width = width;
        Height = height;
        grid = new int[width, height];
    }

    public int this[int x, int y]
    {
        get => grid[x, y];
        set => grid[x, y] = value;
    }
}
