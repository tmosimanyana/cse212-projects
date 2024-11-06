public class Person
{
    public string Name { get; set; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    // Overriding ToString for better test output
    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}
