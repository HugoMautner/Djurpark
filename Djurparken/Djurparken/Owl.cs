using System;

public class Owl : Animal
{
    public float WingSpan { get; private set; }
    public int speciesIndex = 2;

    public Owl(string name, int id, float wingSpan) : base(name, id)
    {
        wingSpan = WingSpan;

        if (wingSpan < 0)
            throw new ArgumentException();

    }
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + WingSpan;
    }
}
