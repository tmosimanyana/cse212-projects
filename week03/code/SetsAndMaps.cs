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
