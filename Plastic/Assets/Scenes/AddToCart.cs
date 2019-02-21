using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCart : MonoBehaviour
{
    public Item apple;
    // Start is called before the first frame update
    void Start()
    {
        apple.name = "apple";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Inventory.Add(apple,1, false);
        Destroy(gameObject);
    }
}
