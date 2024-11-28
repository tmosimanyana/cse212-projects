using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YourNamespace.Tests
{
    [TestClass]
    public class TakingTurnsQueue_Tests
    {
        [TestMethod]
        public void TestTakingTurnsQueue_FiniteRepetition()
        {
            // Defect(s) Found: Infinite loops for persons with infinite turns were not handled.
            // Fix: Re-enqueue persons with infinite turns correctly in GetNextPerson.

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
                Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson());
                i++;
            }
        }

        [TestMethod]
        public void TestTakingTurnsQueue_AddPlayerMidway()
        {
            // Defect(s) Found: Adding a player midway did not consider their turns properly.
            // Fix: Ensure newly added persons are handled correctly.

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
                Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson());
            }

            players.AddPerson("George", 3);

            int j = 5;
            while (players.Length > 0)
            {
                Assert.AreEqual(expectedResult[j].Name, players.GetNextPerson());
                j++;
            }
        }

        [TestMethod]
        public void TestTakingTurnsQueue_ForeverZero()
        {
            // Defect(s) Found: Infinite turns not being re-enqueued correctly.
            // Fix: Re-enqueue persons with zero or infinite turns properly.

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
                Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestTakingTurnsQueue_Empty()
        {
            // Defect(s) Found: No exception thrown for empty queue on dequeue.
            // Fix: Throw InvalidOperationException for empty queue access.

            var players = new TakingTurnsQueue();
            players.GetNextPerson();
        }
    }
}

