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
        savers.Add("tupperware", new Item("tupperware", "savers/tupperwarePrefab"));
        savers.Add("bags", new Item("bags", ""));
        savers.Add("mesh", new Item("mesh", ""));
        savers.Add("jar", new Item("jar", ""));
    }
}
