using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public string imagePath;
    public float plasticAmount;

    public Item(string name, float cost)
    {
        this.name = name;
        this.plasticAmount = cost;
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public float Cost
    {
        get
        {
            return plasticAmount;
        }

        set
        {
            plasticAmount = value;
        }
    }
}
