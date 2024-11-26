using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        string[] expectedResult = { "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim" };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], players.GetNextPerson().Name);
        }
    }

    [TestMethod]
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        string[] expectedResult = { "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "George", "Sue", "Tim", "George", "Tim", "George" };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual(expectedResult[i], players.GetNextPerson().Name);
        }

        players.AddPerson(george.Name, george.Turns);

        for (int i = 5; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], players.GetNextPerson().Name);
        }
    }

    [TestMethod]
    public void TestTakingTurnsQueue_EmptyQueue()
    {
        var players = new TakingTurnsQueue();
        Assert.ThrowsException<InvalidOperationException>(() => players.GetNextPerson());
    }
}
