using System;

public class Tiger : Animal
{
    public float Weight { get; private set; }
    public int speciesIndex = 1;

    public Tiger(int id, string name, float weight) : base(id, name)
    {
        weight = Weight;

        if (weight < 0)
            throw new ArgumentException();
    }
    
    public override int GetId()
    {
        Random rnd = new Random();

        return rnd.Next(000000, 999999);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + Weight;
    }
}