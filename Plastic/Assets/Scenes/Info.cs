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
    // Start is called before the first frame update
    void Start()
    {
        dia = GameObject.Find("Dia");
        dia.GetComponentInChildren<Text>().text = intro;
        plasticInfo = new Dictionary<string, string>();
        noPlasticInfo = new Dictionary<string, string>();
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

    void CreateInfoDictionaries()
    {
        plasticInfo.Add("apples", "Apples come with plastic stickers");
        plasticInfo.Add("beef", "");
        plasticInfo.Add("broth", "");
        plasticInfo.Add("eggs", "");
        plasticInfo.Add("lettuce","");
        plasticInfo.Add("strawberries","");
        plasticInfo.Add("milk", "");
        plasticInfo.Add("nuts", "");
        plasticInfo.Add("cookies", "");

        noPlasticInfo.Add("broth", "");
        noPlasticInfo.Add("beef", "");
        noPlasticInfo.Add("lettuce", "");
        noPlasticInfo.Add("eggs", "");
        noPlasticInfo.Add("nuts", "");
    }
}
