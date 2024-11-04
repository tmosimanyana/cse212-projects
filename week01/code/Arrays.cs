public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. 
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the size equal to 'length'.
        double[] multiples = new double[length];

        // Step 2: Use a for loop to populate the array with multiples of 'number'.
        for (int i = 0; i < length; i++)
        {
            // Step 2a: Calculate the multiple for the current index.
            multiples[i] = number * (i + 1); // i + 1 gives us the correct multiple starting from 1
        }

        // Step 3: Return the array containing the multiples.
        return multiples;
    }
}
