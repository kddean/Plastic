using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public InventorySlot activeItem;
    public Plastic plasticAmount;
    public Dictionary<string, Item> plasticItems;
    public Dictionary<string, Item> nonplasticItems;
    // Start is called before the first frame update
    void Start()
    {
        //Inventory.Testing();
        plasticItems = new Dictionary<string, Item>();
        nonplasticItems = new Dictionary<string, Item>();
        CreatePlasticLists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateInventory()
    {
        InventorySlot[] slots = GameObject.FindObjectsOfType<InventorySlot>();
        foreach (InventorySlot s in slots){
            s.item = null;
            s.gameObject.GetComponentsInChildren<Image>()[1].enabled = false;
        }
    }
    void CreatePlasticLists()
    {
        plasticItems.Add("apples", new Item("apples", 0.01f));
        plasticItems.Add("beef", new Item("beef", 0.03f));
        plasticItems.Add("broth", new Item("broth", 0.02f));
        plasticItems.Add("eggs", new Item("eggs", 0.2f));
        plasticItems.Add("lettuce", new Item("lettuce", 0.2f));
        plasticItems.Add("strawberries", new Item("strawberries", 0.3f));

        nonplasticItems.Add("beef", new Item("beef", 0));
        nonplasticItems.Add("lettuce", new Item("lettuce", 0));
        nonplasticItems.Add("broth", new Item("broth", 0));
        nonplasticItems.Add("eggs", new Item("eggs", 0));
  
    }
}
