using System;
using System.Collections.Generic;
using System.Text;

class Tiger : Animal
{
    private float weight;


    public int GetId()
    {
        //calculate weight + whatever
        return id;
    }
    public string GetName()
    {
        return name;
    }
    public float GetWeight()
    {
        return weight;
    }
    public bool GetLiving()
    {
        return living;
    }



    public override string ToString()
    {
        return base.ToString() + ", " + weight;
    }
}