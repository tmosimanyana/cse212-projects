namespace RecursionSolver
{
    public static class Recursion
    {
        // Problem 1: Sum of squares using recursion
        public static int SumSquaresRecursive(int n)
        {
            if (n <= 0)
                return 0;
            return n * n + SumSquaresRecursive(n - 1);
        }

        // Problem 2: Permutations choose (generating permutations)
        public static void PermutationsChoose(List<string> results, string letters, int size, string current = "")
        {
            if (current.Length == size)
            {
                results.Add(current);
                return;
            }

            foreach (char letter in letters)
            {
                string remaining = letters.Replace(letter.ToString(), "");
                PermutationsChoose(results, remaining, size, current + letter);
            }
        }

        // Problem 3: Counting ways to climb stairs (with memoization)
        public static int CountWaysToClimb(int s, Dictionary<int, int> memo)
        {
            if (s < 0)
                return 0;
            if (s == 0)
                return 1;

            if (memo.ContainsKey(s))
                return memo[s];

            memo[s] = CountWaysToClimb(s - 1, memo) + CountWaysToClimb(s - 2, memo) + CountWaysToClimb(s - 3, memo);
            return memo[s];
        }

        // Problem 4: Wildcard binary patterns generation
        public static void WildcardBinaryPatterns(List<string> results, string pattern, string current = "")
        {
            if (!pattern.Contains('*'))
            {
                results.Add(current + pattern);
                return;
            }

            int index = pattern.IndexOf('*');
            string before = pattern.Substring(0, index);
            string after = pattern.Substring(index + 1);

            WildcardBinaryPatterns(results, before + "0" + after, current);
            WildcardBinaryPatterns(results, before + "1" + after, current);
        }
    }
}

