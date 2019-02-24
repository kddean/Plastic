using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject dia;
    string intro = "Welcome to the Plastic Prototype";
    string appleInfo = "Apples come with plastic stickers";
    Dictionary<string, string> plasticInfo;
    Dictionary<string, string> noPlasticInfo;
    Dictionary<string, string> inventoryInfo;
    // Start is called before the first frame update
    void Start()
    {
        dia = GameObject.Find("Dia");
        dia.GetComponentInChildren<Text>().text = intro;
        plasticInfo = new Dictionary<string, string>();
        noPlasticInfo = new Dictionary<string, string>();
        inventoryInfo = new Dictionary<string, string>();
        CreateInfoDictionaries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(bool plastic, Item item)
    {
        if (plastic)
        {
            Debug.Log(item.name);
                dia.GetComponentInChildren<Text>().text = plasticInfo[item.name];
        }
        else
        {
                dia.GetComponentInChildren<Text>().text = noPlasticInfo[item.name];
        }
    }
    public void UpdateInventoryText(string s)
    {
        dia.GetComponentInChildren<Text>().text = inventoryInfo[s];
    }

    void CreateInfoDictionaries()
    {
        plasticInfo.Add("apples", "Most people place their produce in the plastic bags provided by grocery stores without even thinking about it. Do you really need that extra bag?");
        plasticInfo.Add("beef", "Most packaged meats in stores are placed on styrofoam trays and wrapped in cling wrap. Neither of these plastics are recyclable. Do you think there's way to purchase meat without using single-use plastics next time?");
        plasticInfo.Add("broth", "While it may not look like it, these cartons are lined with plastic. Because these cartons are made out of mixed materials, they cannot be recycled.");
        plasticInfo.Add("eggs", "Unfortunately, most 'free range' and 'organic' eggs are sold in styrofoam or plastic. These materials will never fully break down, and will likely end up in the ocean.");
        plasticInfo.Add("lettuce", "Many greens sold by chain grocery stores come pre-wrapped in plastic. Certain varieties are easier to buy plastic-free than others.");
        plasticInfo.Add("strawberries", "It's almost impossible to buy berries in grocery stores without bringing home some plastic too. If possible, try to get your berries at local farmer's markets, where they're more frequently found in cardboard cartons.");
        plasticInfo.Add("milk", "It's very difficult to buy milk without also buying plastic. While milk jugs are easy to recycle, plastic recycling is inefficient and unprofitable since a recycled plastic degrades quickly. ");
        plasticInfo.Add("nuts", "While buying pre-packaged snacks off the shelf might be easy, there's probably a way to reduce your plastic consumption next time...");
        plasticInfo.Add("cookies", "These cookies are packaged with a non-recyclable plastic wrapper, as well as an interior tray that's also made of plastic.");
        plasticInfo.Add("boxcookies", "At first glance, it looks like these cookies are plastic-free, unfortunately, most cookies and crackers have an interior plastic bag that cannot be recycled.");
        plasticInfo.Add("malk", "While these cartons look like they use less plastic at first glance, they're all lined with plastic and include a plastic spout and lid. Unfortunately, since these cartons are made from a mix of plastic and cardboard, they can almost never be recycled.");

        noPlasticInfo.Add("broth", "Cans maybe a little less convenient, but don't contain any plastic. In addition, the tin used to make the cans is easy and profitable to recycle. ");
        noPlasticInfo.Add("beef", "Most stores are happy to package meat and fish for you at the meat counter. This not only reduces your plastic consumption, but also lets you pick exactly how much you want!");
        noPlasticInfo.Add("lettuce", "While the twist-ties holding greens together in stores are frequently made of plastic, buying unwrapped lettuce can significantly reduce your consumption of single-use plastics.");
        noPlasticInfo.Add("eggs", "Cardboard egg cartons can be recycled, and since they're not made of plastic, they eventually biodegrade anyways.");
        noPlasticInfo.Add("nuts", "Most stores allow you to bring your own bags or jars to their bulk sections as long as your record the weight of your container first. Doing this almost completely eradicates your plastic waste! ");
    }

    void CreateInventoryDictionary()
    {
        inventoryInfo.Add("jar", "An empty glass jar");
        inventoryInfo.Add("mesh", "A thin mesh bag ");
        inventoryInfo.Add("bags", "A reusable grocery bag you got at an earth day celebration a few years ago");
        inventoryInfo.Add("tupperware", "A good-quality glass container with a plastic snap top.");
    }
}
