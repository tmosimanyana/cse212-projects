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
                    degrees[degree]++; // Increment if the degree is already in the dictionary
                }
                else
                {
                    degrees[degree] = 1; // Add the degree with count 1
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determines if two words are anagrams. Ignores spaces and letter case.
    /// </summary>
    /// <param name="word1">First word</param>
    /// <param name="word2">Second word</param>
    /// <returns>True if the words are anagrams, false otherwise</returns>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize words: remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths differ, they can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Create dictionaries to count letter frequencies
        var letterCount1 = new Dictionary<char, int>();
        var letterCount2 = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (letterCount1.ContainsKey(c))
                letterCount1[c]++;
            else
                letterCount1[c] = 1;
        }

        foreach (var c in word2)
        {
            if (letterCount2.ContainsKey(c))
                letterCount2[c]++;
            else
                letterCount2[c] = 1;
        }

        // Compare the dictionaries
        return letterCount1.SequenceEqual(letterCount2);
    }
}
