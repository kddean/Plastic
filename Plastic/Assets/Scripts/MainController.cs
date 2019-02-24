using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Camera main;
    public Camera start;
    public Camera produce;
    public Camera drygoods;
    public Camera fridge;
    public Camera checkout;
    public Camera currentCamera;

    public Button checkOutButton;
    public Button fridgeButton;
    public Button produceButton;
    public Button drygoodsButton;


    public InventorySlot activeItem;
    public Plastic plasticAmount;
    public Dictionary<string, Item> plasticItems;
    public Dictionary<string, Item> nonplasticItems;
    


    // Start is called before the first frame update
    void Start()
    {
        main.enabled = false;
        start.enabled = true;
        currentCamera = start;
        checkOutButton.enabled = false;
        checkOutButton.gameObject.SetActive(false);
        fridgeButton.enabled = false;
        fridgeButton.gameObject.SetActive(false);
        produceButton.enabled = false;
        produceButton.gameObject.SetActive(false);
        drygoodsButton.enabled = false;
        drygoodsButton.gameObject.SetActive(false);
        //Inventory.Testing();
        plasticItems = new Dictionary<string, Item>();
        nonplasticItems = new Dictionary<string, Item>();
        
        CreatePlasticLists();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCamera != start)
        {
            EnabledCheckoutButton();
        }
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
        plasticItems.Add("milk", new Item("milk", 0.3f));
        plasticItems.Add("nuts", new Item("nuts", 0.03f));
        plasticItems.Add("cookies", new Item("cookies", 0.03f));

        nonplasticItems.Add("beef", new Item("beef", 0));
        nonplasticItems.Add("lettuce", new Item("lettuce", 0));
        nonplasticItems.Add("broth", new Item("broth", 0));
        nonplasticItems.Add("eggs", new Item("eggs", 0));
        nonplasticItems.Add("nuts", new Item("nuts", 0.03f));

    }

    public void ChangeCamera(Camera c)
    {
        if(c.name == "Produce")
        {
            currentCamera.enabled = false;
            currentCamera = produce;
            produce.enabled = true;
            //currentCamera.enabled = true;
        }
        else if(c.name == "Dry Goods")
        {
            currentCamera.enabled = false;
            currentCamera = drygoods;
            drygoods.enabled = true;
        }
        else if(c.name == "Fridge")
        {
            currentCamera.enabled = false;
            currentCamera = fridge;
            fridge.enabled = true;
        }else if(c.name == "Checkout")
        {
            currentCamera.enabled = false;
            currentCamera = checkout;
            checkout.enabled = true;
        }
        
        /*currentCamera.enabled = false;
        currentCamera = c;
        currentCamera.enabled = true;
        */
        //Debug.Log(currentCamera.name);
    }
    
    public void EnabledCheckoutButton()
    {
        checkOutButton.gameObject.SetActive(true);
        checkOutButton.enabled = true;
        
    }
    public void EnabledCorrectButtons(int i)
    {
        if(i == 1)
        {
            produceButton.gameObject.SetActive(false);
            fridgeButton.gameObject.SetActive(true);
            fridgeButton.enabled = true;
            drygoodsButton.gameObject.SetActive(true);
            drygoodsButton.enabled = true;
        }
        else if(i == 2)
        {
            drygoodsButton.gameObject.SetActive(false);
            fridgeButton.gameObject.SetActive(true);
            fridgeButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
        }
        else if( i == 3)
        {
            fridgeButton.gameObject.SetActive(false);
            drygoodsButton.gameObject.SetActive(true);
            drygoodsButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
        }
        else if(i == 0)
        {
            fridgeButton.gameObject.SetActive(true);
            fridgeButton.enabled = true;
            drygoodsButton.gameObject.SetActive(true);
            drygoodsButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
        }
    }

    public void PlasticFree(int i)
    {
        if(activeItem.item.item.name == "jar")
        {


        }
        else if (activeItem.item.item.name == "mesh")
        {

        }
        else if (activeItem.item.item.name == "bags")
        {

        }
        else if (activeItem.item.item.name == "tupperware")
        {

        }
        else
        {

        }
    }
}
