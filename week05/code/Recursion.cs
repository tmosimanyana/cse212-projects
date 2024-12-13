namespace RecursionSolver
{
    public static class Recursion
    {
        public static int SumSquaresRecursive(int n)
        {
            if (n <= 0) return 0;
            return n * n + SumSquaresRecursive(n - 1);
        }

        public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
        {
            if (size == 0)
            {
                results.Add(word);
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                PermutationsChoose(results, letters, size - 1, word + letters[i]);
            }
        }

        public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
        {
            if (s == 0) return 0;
            if (s == 1) return 1;
            if (s == 2) return 2;
            if (s == 3) return 4;

            remember ??= new Dictionary<int, decimal>();

            if (remember.ContainsKey(s)) return remember[s];

            decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
            remember[s] = ways;

            return ways;
        }

        public static void WildcardBinary(string pattern, List<string> results)
        {
            if (pattern.Length == 0)
            {
                results.Add(string.Empty);
                return;
            }

            if (pattern[0] == '*')
            {
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
                List<string> subResults = new List<string>();
                WildcardBinary(pattern.Substring(1), subResults);
                foreach (var subPattern in subResults)
                {
                    results.Add(pattern[0] + subPattern);
                }
            }
        }

        public static void SolveMaze(List<string> results, MazeSolver.Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
        {
            if (currPath == null) currPath = new List<ValueTuple<int, int>>();

            if (x < 0 || y < 0 || x >= maze.GetWidth() || y >= maze.GetHeight() || maze[x, y] == 0) return;

            currPath.Add((x, y));

            if (maze[x, y] == 2)
            {
                results.Add(string.Join(" -> ", currPath.Select(p => $"({p.Item1},{p.Item2})")));
                return;
            }

            maze[x, y] = 0;

            SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath)); // down
            SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath)); // up
            SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath)); // right
            SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath)); // left

            maze[x, y] = 1;
        }
    }
}

