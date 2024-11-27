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
            string reversed = $"{word[1]}{word[0]}"; // Reverse by swapping characters

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

        try
        {
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
                else
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                }
            }
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException($"The file {filename} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
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

        // Use a single dictionary for counting
        var letterCount = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (letterCount.ContainsKey(c))
                letterCount[c]++;
            else
                letterCount[c] = 1;
        }

        foreach (var c in word2)
        {
            if (!letterCount.ContainsKey(c) || letterCount[c] == 0)
                return false;

            letterCount[c]--;
        }

        // Ensure all counts are zero
        return letterCount.Values.All(count => count == 0);
    }

    /// <summary>
    /// Summarizes earthquake data from a JSON file (Extra Credit).
    /// </summary>
    /// <param name="filename">Path to the JSON file</param>
    /// <returns>A dictionary with summary data</returns>
    public static Dictionary<string, int> EarthquakeDailySummary(string filename)
    {
        // TODO: Implement JSON parsing here
        throw new NotImplementedException("This method has not been implemented yet.");
    }
}
