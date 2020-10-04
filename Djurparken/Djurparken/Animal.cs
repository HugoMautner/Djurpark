using System;

public abstract class Animal
{
    public string Name;
    public abstract string GetId();
    public abstract int GetSpecial();
    public abstract string GetSpecies();

    protected bool Living;
    public string LastUpdated { get; protected set; }
    

    public Animal(string name, bool living, string lastUpdated)
    {
        Name = name;
        Living = living;
        LastUpdated = lastUpdated;
    }

    public bool GetLiving()
    {
        return Living;
    }
    public void SetLiving(bool living)
    {
        Living = living;
    }

    public string GetLastUpdated()
    {
        return LastUpdated;
    }
    public void SetLastUpdated(string lastUpdated)
    {
        LastUpdated = lastUpdated;
    }

    public string GetName()
    {
        return Name;
    }

    public override string ToString()
    {
        return (GetId() + "|" + Name + "|" + Living + "|" + LastUpdated);
    }
}