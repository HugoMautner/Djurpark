using System;

public class Elephant : Animal
{
    public float TrunkLength { get; private set; }
    public int speciesIndex = 3;

    public Elephant(string name, int id, float trunkLength) : base(name, id)
    {
        trunkLength = TrunkLength;

        if (trunkLength < 0)
            throw new ArgumentException();
    }
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + TrunkLength;
    }
}
