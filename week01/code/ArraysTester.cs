using System;
using System.Collections.Generic;

public static class ArraysTester 
{
    /// <summary>
    /// Entry point for the tests
    /// </summary>
    public static void Run() 
    {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
    }

    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number</returns>
    private static double[] MultiplesOf(double number, int length)
    {
        // Initialize an array to store the multiples
        double[] multiples = new double[length];

        // Calculate multiples and store them in the array
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }
    
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}</List> and an amount is 3,
    /// then the list returned should be <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 and data.Count.
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    private static void RotateListRight(List<int> data, int amount)
    {
        // Calculate the effective rotation amount using modulo to handle wrap-around
        int rotation = amount % data.Count;

        // No need to rotate if rotation amount is 0
        if (rotation == 0) return;

        // Extract the elements to be rotated
        List<int> rotatedPart = data.GetRange(data.Count - rotation, rotation);

        // Remove the rotated part from the end
        data.RemoveRange(data.Count - rotation, rotation);

        // Insert the rotated part at the beginning
        data.InsertRange(0, rotatedPart);
    }
}
