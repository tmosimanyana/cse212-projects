using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with Bob, Tim, and Sue, run until empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
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
    // Scenario: Queue with Bob, Tim, Sue, and add George midway.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
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
    // Scenario: Queue with Bob (finite), Tim (infinite), and Sue. Run 10 times.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 0);
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
    // Scenario: Get the next person from an empty queue.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        Assert.ThrowsException<InvalidOperationException>(() => players.GetNextPerson());
    }
}
