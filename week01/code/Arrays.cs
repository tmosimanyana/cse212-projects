using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function generates an array of multiples of a given number.
    /// The function takes two parameters: the starting number and the
    /// number of multiples to generate. For example, MultiplesOf(3, 5)
    /// returns {3, 6, 9, 12, 15}.
    /// </summary>
    /// <param name="number">The starting number to generate multiples of.</param>
    /// <param name="length">The number of multiples to generate.</param>
    /// <returns>An array of doubles that contains the multiples.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Initialize an array of size 'length' to hold the multiples.
        double[] multiples = new double[length];

        // Step 2: Use a for loop to fill the array with multiples of 'number'.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate the i-th multiple.
        }

        // Step 3: Return the populated array.
        return multiples;
    }

    /// <summary>
    /// This function rotates the elements of a list to the right by a specified amount.
    /// For example, if the list is {1, 2, 3, 4, 5, 6, 7, 8, 9} and the amount is 5,
    /// the function will modify the list to {5, 6, 7, 8, 9, 1, 2, 3, 4}.
    /// The amount is guaranteed to be between 1 and the count of the list.
    /// </summary>
    /// <param name="data">The list of integers to rotate.</param>
    /// <param name="amount">The number of positions to rotate the list to the right.</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the effective amount to rotate.
        int size = data.Count;
        amount = amount % size; // Handle cases where amount > size.

        // Step 2: If amount is 0, no rotation is necessary.
        if (amount == 0) return;

        // Step 3: Identify the elements to move to the front.
        var toMove = data.GetRange(size - amount, amount); // Get the last 'amount' elements.
        var rest = data.GetRange(0, size - amount); // Get the remaining elements.

        // Step 4: Clear the original list and reassemble it with the rotated order.
        data.Clear(); // Clear the list to prepare for new content.
        data.AddRange(toMove); // Add the moved elements at the front.
        data.AddRange(rest); // Add the remaining elements to the end.
    }
}
