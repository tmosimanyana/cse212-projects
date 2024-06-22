using System;

public static class TakingTurns
{
    public static void Test()
    {
        // Test 1
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        while (players.Length > 0)
            players.GetNextPerson();
        // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 2
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 5; i++)
            players.GetNextPerson();
        players.AddPerson("George", 3);
        while (players.Length > 0)
            players.GetNextPerson();
        // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 3
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 10; i++)
            players.GetNextPerson();
        // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 4
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 10; i++)
            players.GetNextPerson();
        // Expected: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
        // Defect(s) Found:

        Console.WriteLine("---------");

        // Test 5
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        players.GetNextPerson();
        // Expected: Error message should be displayed
        // Defect(s) Found:
    }
}

