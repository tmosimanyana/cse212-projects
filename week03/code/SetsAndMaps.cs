using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two-character 
    /// words (lowercase, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            // Check if the reversed version is already in the set
            if (wordSet.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                // Add the word to the set
                wordSet.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Reads a census file and summarizes the degrees earned by individuals.
    /// The degree information is in the 4th column of the file (index 3).
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>A dictionary where the key is the degree name and the value is the count</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3) // Ensure the line has a 4th column
            {
                string degree = fields[3].Trim(); // Get the degree and trim spaces

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }
}
