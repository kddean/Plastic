using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public class InventoryItem
    {
        public int maxStack = 10;
        public int count = 1;
        public Item item;

        public InventoryItem(Item o, int c)
        {
            item = o;
            count = c;
        }
    }

    public static void Testing()
    {
        Item apple = new Item("apple", 0.2f);
        apple.name = "apple";
        Add(apple, 5, false);
    }

    public static bool Add(Item obj, int count, bool shouldDrop)
    {
        Button[] invButtons = GameObject.FindGameObjectWithTag("inventory").transform.parent.GetComponentsInChildren<Button>();

        foreach (Button b in invButtons)
        {
            InventorySlot slot = b.GetComponent<InventorySlot>();
            //Adding to existing stack
            if (slot.item != null && slot.item.item.name == obj.name && slot.item.count < slot.item.maxStack)
            {
                int remainder = count - (slot.item.maxStack - slot.item.count);
                if (remainder <= 0)
                {
                    slot.item.count = (slot.item.count + count);
                    slot.gameObject.GetComponentInChildren<Text>().text = slot.item.count.ToString();
                    return true;
                }
                else
                {
                    slot.item.count = slot.item.maxStack;
                    foreach (Button bt in invButtons)
                    {
                        InventorySlot s = bt.GetComponent<InventorySlot>();
                        if (s.item == null)
                        {
                            s.item = new InventoryItem(obj, remainder);
                            s.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(obj.imagePath);
                            if (s.item.count > 1)
                            {
                                s.gameObject.GetComponentInChildren<Text>().text = s.item.count.ToString();
                            }
                            else
                            {
                                s.gameObject.GetComponentInChildren<Text>().text = "";
                            }
                            return true;
                        }
                    }
                }
            }
        }
        //Creating new stack
        foreach (Button b in invButtons)
        {
            InventorySlot s = b.GetComponent<InventorySlot>();
            if (s.item == null)
            {
                s.item = new InventoryItem(obj, count);
                s.gameObject.GetComponent<Image>().enabled = true;
                s.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(obj.imagePath);
                if (s.item.count > 1)
                {
                    s.gameObject.GetComponentInChildren<Text>().text = s.item.count.ToString();
                }
                else
                {
                    s.gameObject.GetComponentInChildren<Text>().text = "";
                }
                return true;
            }
        }
        return false;
    }

    public static void RemoveItem(InventorySlot slot)
    {
        Button[] invButtons = GameObject.FindGameObjectWithTag("inventory").transform.parent.GetComponentsInChildren<Button>();
        if (slot.item.count == 1)
        {
            RemoveStack(slot);
        }
        else
        {
            slot.item.count--;
            if (slot.item.count == 1)
            {
                slot.gameObject.GetComponentInChildren<Text>().text = "";
            }
            else
            {
                slot.gameObject.GetComponentInChildren<Text>().text = slot.item.count.ToString();
            }
        }
    }

    public static void RemoveStack(InventorySlot item)
    {
        item.gameObject.GetComponentInChildren<Image>().enabled = false;
        item.gameObject.GetComponentInChildren<Text>().text = "";
        item.item = null;
    }

}

