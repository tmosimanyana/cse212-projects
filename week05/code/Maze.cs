using System;
using System.Collections.Generic;

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    // Helper function to determine if the (x, y) position is at the end of the maze
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }

    // Helper function to determine if the (x, y) position is a valid move
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // Can't go outside the maze boundary
        if (x > Width - 1 || x < 0 || y > Height - 1 || y < 0)
            return false;
        // Can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // Can't go if we've already been there
        if (currPath.Contains((x, y)))
            return false;
        return true;
    }

    // Recursive function to solve the maze and find all paths to the end
    public void SolveMaze(int x, int y, List<ValueTuple<int, int>> currPath, List<string> results)
    {
        // Base case: If we reach the end of the maze, add the current path to results
        if (IsEnd(x, y))
        {
            currPath.Add((x, y));  // Add the final position to the path
            results.Add(PathToString(currPath));  // Convert path to string and add it to the results
            currPath.RemoveAt(currPath.Count - 1);  // Remove the last position for backtracking
            return;
        }

        // Add current position to the path
        currPath.Add((x, y));

        // Explore all possible directions: Right, Down, Left, Up
        // Right
        if (IsValidMove(currPath, x + 1, y))
            SolveMaze(x + 1, y, currPath, results);
        
        // Down
        if (IsValidMove(currPath, x, y + 1))
            SolveMaze(x, y + 1, currPath, results);

        // Left
        if (IsValidMove(currPath, x - 1, y))
            SolveMaze(x - 1, y, currPath, results);

        // Up
        if (IsValidMove(currPath, x, y - 1))
            SolveMaze(x, y - 1, currPath, results);

        // Backtrack: remove the current position and try other paths
        currPath.RemoveAt(currPath.Count - 1);
    }

    // Helper method to convert a path to a string representation
    private string PathToString(List<ValueTuple<int, int>> path)
    {
        var pathString = "";
        foreach (var (x, y) in path)
        {
            pathString += $"({x},{y}) ";
        }
        return pathString.Trim();
    }
}
