using System;

public abstract class Animal
{
    public string Name { get; protected set; }
    public abstract int GetId();
    public bool Living { get; protected set; }


    public Animal(int id, string name)
    {
        Name = name;
        id = 100200;
    }

    public override string ToString()
    {
        return (GetId() + ", " + Name + ", ");
    }
}