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
    public Dictionary<string, Item> saverItems;
    //public GameObject shoppingList;
    public Text[] shoppingList = new Text[9];
    


    // Start is called before the first frame update
    void Start()
    {
        activeItem = null;
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
        saverItems = new Dictionary<string, Item>();
        
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
        plasticItems.Add("boxcookies", new Item("boxcookies", 0.02f));
        plasticItems.Add("malk", new Item("malk", 0.02f));
        plasticItems.Add("bagnuts", new Item("bagnuts", 0.02f));

        nonplasticItems.Add("beef", new Item("beef", 0));
        nonplasticItems.Add("lettuce", new Item("lettuce", 0));
        nonplasticItems.Add("broth", new Item("broth", 0));
        nonplasticItems.Add("eggs", new Item("eggs", 0));
        nonplasticItems.Add("nuts", new Item("nuts", 0.03f));

        saverItems.Add("tupperware", new Item("tupperware", "savers/tupperware"));
        saverItems.Add("bags", new Item("bags", "savers/reusebag"));
        saverItems.Add("mesh", new Item("mesh", "savers/meshbag"));
        saverItems.Add("jar", new Item("jar", "savers/jar"));

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
            EnabledCheckoutButton();
        }
        else if(i == 2)
        {
            drygoodsButton.gameObject.SetActive(false);
            fridgeButton.gameObject.SetActive(true);
            fridgeButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
            EnabledCheckoutButton();
        }
        else if( i == 3)
        {
            fridgeButton.gameObject.SetActive(false);
            drygoodsButton.gameObject.SetActive(true);
            drygoodsButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
            EnabledCheckoutButton();
        }
        else if(i == 0)
        {
            fridgeButton.gameObject.SetActive(true);
            fridgeButton.enabled = true;
            drygoodsButton.gameObject.SetActive(true);
            drygoodsButton.enabled = true;
            produceButton.gameObject.SetActive(true);
            produceButton.enabled = true;
            checkOutButton.gameObject.SetActive(false);
        }
    }

    public void PlasticFree(int i)
    {
        if (activeItem.item.item.name == "jar" && i == 1)
        {
            this.GetComponent<Info>().UpdateSaverText(activeItem.item.item);
            GetComponent<Cart>().cart.Add(saverItems["jar"]);
            Debug.Log("That's alot of nuts");
            DestroyImmediate(shoppingList[2]);
        }
        else if (activeItem.item.item.name == "mesh")
        {
            this.GetComponent<Info>().UpdateSaverText(activeItem.item.item);
            GetComponent<Cart>().cart.Add(saverItems["mesh"]);
        }
        else if (activeItem.item.item.name == "bags")
        {
            this.GetComponent<Info>().UpdateSaverText(activeItem.item.item);
            GetComponent<Cart>().cart.Add(saverItems["bags"]);
        }
        else if (activeItem.item.item.name == "tupperware" && i == 0)
        {
            this.GetComponent<Info>().UpdateSaverText(activeItem.item.item);
            GetComponent<Cart>().cart.Add(saverItems["tupperware"]);
            Debug.Log("Saved with Tupperware");
            DestroyImmediate(shoppingList[5]);
        }
        else
        {
            Debug.Log("Not Saving");
        }
    }
    public void crossOfList(string s)
    {
        if(s == "apples")
        {
            DestroyImmediate(shoppingList[0]);
        }
        else if (s.Contains("lettuce"))
        {
            DestroyImmediate(shoppingList[1]);
        }
        else if (s.Contains("nuts"))
        {
            DestroyImmediate(shoppingList[2]);
        }
        else if (s.Contains("milk") || s.Contains("malk"))
        {
            DestroyImmediate(shoppingList[3]);
        }
        else if (s.Contains("cookies"))
        {
            DestroyImmediate(shoppingList[4]);
        }
        else if (s.Contains("beef"))
        {
            DestroyImmediate(shoppingList[5]);
        }
        else if (s.Contains("broth"))
        {
            DestroyImmediate(shoppingList[6]);
        }
        else if (s.Contains("strawberries"))
        {
            DestroyImmediate(shoppingList[7]);
        }
        else if (s.Contains("eggs"))
        {
            DestroyImmediate(shoppingList[8]);
        }
    }
    public void CheckOut()
    {
        if( activeItem == null)
        {
            GetComponent<Info>().dia.GetComponentInChildren<Text>().text = "You forgot your reuseablebags and had to use plastic";
            GameObject.FindObjectOfType<Plastic>().UpdatePlasticMeter(0.5f);
        }
        else if (activeItem.item.item.name == "bags")
        {
            this.GetComponent<Info>().UpdateSaverText(activeItem.item.item);

        }
        else
        {
            GetComponent<Info>().dia.GetComponentInChildren<Text>().text = "You forgot your reuseablebags and had to use plastic";
            GameObject.FindObjectOfType<Plastic>().UpdatePlasticMeter(0.5f);
        }
    }
}
