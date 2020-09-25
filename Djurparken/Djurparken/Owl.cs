using System;

public class Owl : Animal
{
    public decimal WingSpan { get; private set; }
    public int speciesIndex = 2;
    public bool living { get; private set; }

    public Owl(string name, decimal wingSpan, bool living) : base(name, living)
    {
        if (wingSpan < 0)
            throw new ArgumentException();
        wingSpan = WingSpan;


    }
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + WingSpan + ", " + speciesIndex;
    }
}
