using System;
using System.Collections.Generic;
using System.Text;

class Elephant : Animal
{
    private float trunkLength;

    public int GetId()
    {
        //calculate trunk + whatever
        return id;
    }
    public string GetName()
    {
        return name;
    }
    public float GetTrunkLength()
    {
        return trunkLength;
    }
    public bool GetLiving()
    {
        return living;
    }

    //needs specific constructor

    public override string ToString()
    {
        return base.ToString() + ", " + trunkLength;
    }
}