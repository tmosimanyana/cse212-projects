using System;
using System.Collections.Generic;

namespace RecursionSolver
{
    public static class Recursion
    {
        // Problem 1: Recursive Squares Sum
        public static int SumSquaresRecursive(int n)
        {
            if (n <= 0) return 0;
            return n * n + SumSquaresRecursive(n - 1);
        }

        // Problem 2: Permutations Choose
        public static void PermutationsChoose(List<string> results, string letters, int size, string current = "")
        {
            if (current.Length == size)
            {
                results.Add(current);
                return;
            }

            foreach (char c in letters)
            {
                PermutationsChoose(results, letters.Replace(c.ToString(), ""), size, current + c);
            }
        }

        // Problem 3: Climbing Stairs
        public static int CountWaysToClimb(int s, Dictionary<int, int> remember)
        {
            if (s < 0) return 0;
            if (s == 0) return 1;

            if (remember.ContainsKey(s)) return remember[s];

            remember[s] = CountWaysToClimb(s - 1, remember) + 
                          CountWaysToClimb(s - 2, remember) + 
                          CountWaysToClimb(s - 3, remember);

            return remember[s];
        }

        // Problem 4: Wildcard Binary Patterns
        public static void WildcardBinaryPatterns(List<string> results, string pattern, int index = 0)
        {
            if (index == pattern.Length)
            {
                results.Add(pattern);
                return;
            }

            if (pattern[index] == '*')
            {
                WildcardBinaryPatterns(results, pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), index + 1);
                WildcardBinaryPatterns(results, pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), index + 1);
            }
            else
            {
                WildcardBinaryPatterns(results, pattern, index + 1);
            }
        }

        // Problem 5: Maze Solver
        public static void SolveMaze(List<string> results, MazeSolver.Maze maze, List<(int, int)> currPath = null, int x = 0, int y = 0)
        {
            if (currPath == null) currPath = new List<(int, int)>();

            if (!maze.IsValidMove(x, y, currPath)) return;

            currPath.Add((x, y));

            if (maze.IsEnd(x, y))
            {
                results.Add(currPath.AsString());
                currPath.RemoveAt(currPath.Count - 1);
                return;
            }

            SolveMaze(results, maze, currPath, x + 1, y); // Move right
            SolveMaze(results, maze, currPath, x - 1, y); // Move left
            SolveMaze(results, maze, currPath, x, y + 1); // Move down
            SolveMaze(results, maze, currPath, x, y - 1); // Move up

            currPath.RemoveAt(currPath.Count - 1);
        }
    }

    public static class TupleListExtensionMethods
    {
        public static string AsString(this IEnumerable<(int, int)> list)
        {
            return "<List>{" + string.Join(", ", list) + "}";
        }
    }
}

namespace MazeSolver
{
    public class Maze
    {
        private int[,] _mazeArray;
        public int Width { get; }
        public int Height { get; }

        public Maze(int[,] mazeArray)
        {
            _mazeArray = mazeArray;
            Width = mazeArray.GetLength(1);
            Height = mazeArray.GetLength(0);
        }

        public bool IsValidMove(int x, int y, List<(int, int)> path)
        {
            return x >= 0 && y >= 0 && x < Height && y < Width && _mazeArray[x, y] != 0 && !path.Contains((x, y));
        }

        public bool IsEnd(int x, int y)
        {
            return _mazeArray[x, y] == 2;
        }
    }
}
