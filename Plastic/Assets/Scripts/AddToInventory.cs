using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    MainController mc;
    Dictionary<string, Item> savers;
    Item tupperware;
    Item bags;

    //Produce
    //Dry Goods
    //Eggs
    //Checkout
    //Start
   
    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.FindObjectOfType<MainController>();
        savers = new Dictionary<string, Item>();
        CreateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Inventory.Add(savers[this.gameObject.name], 1, false);
    }

    void CreateItems()
    {
        savers.Add("tupperware", new Item("tupperware", "savers/tupperware"));
        savers.Add("bags", new Item("bags", "savers/reusebag"));
        savers.Add("mesh", new Item("mesh", "savers/meshbag"));
        savers.Add("jar", new Item("jar", "savers/jar"));
    }
}
