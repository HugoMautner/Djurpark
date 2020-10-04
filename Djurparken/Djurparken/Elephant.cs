using System;

public class Elephant : Animal
{
    private int TrunkLength;

    public Elephant(string name, int trunkLength, bool living, string lastUpdated) : base(name, living, lastUpdated)
    {
        TrunkLength = trunkLength;
    }
    public int GetTrunkLength()
    {
        return TrunkLength;
    }
    public void SetTrunkLength(int trunkLength)
    {
        TrunkLength = trunkLength;
    }
    public override int GetSpecial()
    {
        return TrunkLength;
    }
    public override string GetSpecies()
    {
        return "elephant";
    }

    //Calculates id for instances of the Elephant class. Value returned overrides mother-class' abstract method GetId()
    //This solution grants GetId() access of all animals's id, and inherited classes can specify their id individually with the override keyword
    //
    //id is assigned local value of TrunkLegth. Adds id to id until id.Length == 6. 
    //Removes characters from id, starting at index 6, then returns finished id.
    public override string GetId()
    {
        string id = TrunkLength.ToString();

        while (id.Length < 6)
        {
            id += id;
        }
        
        if (id.Length > 6)
        {
            string realId = id.Remove(6);
            return realId;
        }

        return id;
    }

    public override string ToString()
    {
        return base.ToString() + "|" + TrunkLength + "|" + GetSpecies();
    }
}