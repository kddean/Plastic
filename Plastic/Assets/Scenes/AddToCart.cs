using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCart : MonoBehaviour
{
    MainController mc;
    public Item apple;
    public bool hasPlastic;
    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.FindObjectOfType<MainController>();
        apple.name = "apple";
        apple.plasticAmount = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hasPlastic)
        {
            //Inventory.Add(apple, 1, false);
            GameObject.FindObjectOfType<Plastic>().UpdatePlasticMeter(mc.plasticItems[this.gameObject.name].plasticAmount);
            mc.GetComponent<Info>().UpdateText(true, mc.plasticItems[this.gameObject.name]);
            mc.GetComponent<Cart>().cart.Add(mc.plasticItems[this.gameObject.name]);
            Destroy(this.gameObject);
        }
        else
        {
            mc.GetComponent<Info>().UpdateText(true, mc.nonplasticItems[this.gameObject.name]);
            mc.GetComponent<Cart>().cart.Add(mc.nonplasticItems[this.gameObject.name]);
            Destroy(this.gameObject);
        }
    }
}
