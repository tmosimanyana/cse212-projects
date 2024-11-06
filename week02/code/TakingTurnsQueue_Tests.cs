using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    // Test Scenario: Run until queue is empty.
    // Expected result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = new[] { bob, tim, sue, bob, tim, sue, tim, sue, tim, tim };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
            i++;
        }
    }

    [TestMethod]
    // Test Scenario: Adding George midway through the queue.
    // Expected result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = new[] { bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
        }

        players.AddPerson("George", 3);

        int j = 5;
        while (players.Length > 0)
        {
            Assert.AreEqual(expectedResult[j].Name, players.GetNextPerson().Name);
            j++;
        }
    }

    [TestMethod]
    // Test Scenario: Tim has infinite turns, and the others have finite turns.
    // Expected result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 0);  // Infinite turns
        var sue = new Person("Sue", 3);

        Person[] expectedResult = new[] { bob, tim, sue, bob, tim, sue, tim, sue, tim, tim };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
        }
    }

    [TestMethod]
    // Test Scenario: Handle empty queue.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();
        players.GetNextPerson(); // Should throw exception as queue is empty
    }
}
