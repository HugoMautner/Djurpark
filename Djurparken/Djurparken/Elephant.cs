using System;

public class Elephant : Animal
{
    public decimal TrunkLength { get; private set; }
    public int speciesIndex = 3;
    public bool living { get; private set; }

    public Elephant(string name, decimal trunkLength, bool living) : base(name, living)
    {
        if (trunkLength < 0)
            throw new ArgumentException();
        trunkLength = TrunkLength;

        
    }
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + TrunkLength + ", " + speciesIndex;
    }
}
