using MazeSolver;
using RecursionSolver;

class Program
{
    static void Main(string[] args)
    {
        int[,] mazeArray = new int[,] {
            { 1, 1, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 2 },
        };

        MazeSolver.Maze maze = new MazeSolver.Maze(mazeArray);
        
        List<string> paths = new List<string>();
        RecursionSolver.Recursion.SolveMaze(paths, maze);

        Console.WriteLine("Possible paths:");
        foreach (var path in paths)
        {
            Console.WriteLine(path);
        }

        int n = 5;
        int sum = RecursionSolver.Recursion.SumSquaresRecursive(n);
        Console.WriteLine($"Sum of squares from 1 to {n}: {sum}");

        List<string> permutations = new List<string>();
        RecursionSolver.Recursion.PermutationsChoose(permutations, "abc", 2);
        Console.WriteLine("Permutations of length 2 from 'abc':");
        foreach (var perm in permutations)
        {
            Console.WriteLine(perm);
        }
    }
}
