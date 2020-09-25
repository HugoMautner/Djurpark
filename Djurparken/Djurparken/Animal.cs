using System;

public abstract class Animal
{
    public string Name { get; protected set; }
    public abstract int GetId();
    public bool Living { get; protected set; }

    public Animal(string name, bool living)
    {
        Name = name;
        Living = living;
    }

    public override string ToString()
    {
        return (GetId() + ", " + Name + ", " + Living);
    }
}