using System;

public class Owl : Animal
{
    private int Wingspan;

    public Owl(string name, int wingspan, bool living, string lastUpdated) : base(name, living, lastUpdated)
    {
        Wingspan = wingspan;
    }
    public int GetWingspan()
    {
        return Wingspan;
    }
    public void SetWingspan(int wingspan)
    {
        Wingspan = wingspan;
    }
    public override int GetSpecial()
    {
        return Wingspan;
    }
    public override string GetSpecies()
    {
        return "owl";
    }

    //Calculates id for instances of the Owl class. Value returned overrides mother-class' abstract method GetId()
    //This solution grants GetId() access of all animals's id, and inherited classes can specify their id individually with the override keyword
    //
    //string idFirst is assigned class' Wingspan with ToString(). Adds "0" to start of idFirst until idFirst.Length == 3. 
    //string idSecond is assigned the ToString value of a random int between 100 and 999, using the Random.Next method. 
    //string id is assigned concatenation of idFirst and idSecond, then returned
    public override string GetId()
    {
        string idFirst = Wingspan.ToString();

        while (idFirst.Length < 3)
        {
            idFirst = "0" + idFirst;
        }

        Random rng = new Random();
        string idSecond = rng.Next(100, 999).ToString();

        string id = idFirst + idSecond;

        return id;
    }

    public override string ToString()
    {
        return base.ToString() + "|" + Wingspan + "|" + GetSpecies();
    }
}