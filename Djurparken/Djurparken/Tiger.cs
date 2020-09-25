using System;

public class Tiger : Animal
{
    public decimal Weight { get; private set; }
    public int speciesIndex = 1;
    public bool living { get; private set; }

    public Tiger(string name, decimal weight, bool living) : base(name, living)
    {
        if (weight < 0)
            throw new ArgumentException();
        weight = Weight;


    }
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + Weight + ", " + speciesIndex;
    }
}