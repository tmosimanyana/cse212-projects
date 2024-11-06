public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; }

    // Constructor for initializing a Person object with a name and number of turns
    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    // Override ToString() method to display the Person's name and turns
    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}
