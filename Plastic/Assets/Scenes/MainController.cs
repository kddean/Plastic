using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public InventorySlot activeItem;
    // Start is called before the first frame update
    void Start()
    {
        Inventory.Testing();
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
}
