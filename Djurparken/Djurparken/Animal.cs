using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    protected int id;
    protected string name;
    protected bool living = true;


    public override string ToString()
    {
        return id + ", " + name + ", " + living;
    }
}