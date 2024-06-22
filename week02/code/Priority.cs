using System;

public static class Priority
{
    public static void Test()
    {
        // Test 1
        Console.WriteLine("Test 1");
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        // Expected: B, C, A
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 2
        Console.WriteLine("Test 2");
        pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 3);
        pq.Enqueue("D", 2);
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        // Expected: B, C, D, A
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 3
        Console.WriteLine("Test 3");
        pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        Console.WriteLine(pq.Dequeue());
        // Expected: A
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 4
        Console.WriteLine("Test 4");
        pq = new PriorityQueue();
        Console.WriteLine(pq.Dequeue());
        // Expected: Error: Queue is empty
        // Defect(s) Found:
    }
}
