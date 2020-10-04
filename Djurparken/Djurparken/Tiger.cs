using System;

public class Tiger : Animal
{
    private int Weight;

    public Tiger(string name, int weight, bool living, string lastUpdated) : base(name, living, lastUpdated)
    {
        Weight = weight;
    }
    public int GetWeight()
    {
        return Weight;
    }
    public void SetWeight(int weight)
    {
        Weight = weight;
    }

    public override int GetSpecial()
    {
        return Weight;
    }

    public override string GetSpecies()
    {
        return "tiger";
    }

    //Calculates id for instances of the Tiger class. Value returned overrides mother-class' abstract method GetId()
    //This solution grants GetId() access of all animals's id, and inherited classes can specify their id individually with the override keyword
    //
    //int baseId is assigned local int Weight. Value of first 3 chars in class' string Name (or 2, or 1 if Name length < 3)
    //is multiplied to baseId, which is then made into string id. "0" is added to id until id.Length == 6. 
    //Trims id of characters after index (6), then finished id is returned.
    public override string GetId()
    {
        int baseId = Weight;
        for (int i = 0; i < 3 && i < Name.ToCharArray().Length; i++)
        {
            baseId *= Name.ToCharArray()[i];
        }
        string id = Math.Abs(baseId).ToString();

        while (id.Length < 6)
        {
            id += "0";
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
        return base.ToString() + "|" + Weight + "|" + GetSpecies();
    }
}