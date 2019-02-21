using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    Transform startingParent;
    Transform canvas;
    public Inventory.InventoryItem item;
    //ResourceLoader rl;
    int index;
    Vector3 temp;
    bool set = false;
    public GameObject tooltip;
    //tooltip text
    Text[] text;
    //flags for displaying tooltips
    bool hovered = false;
    //tooltip offset
    bool dragging = false;
    bool filledStack = false;
    bool triedBrewing = false;
    Vector3 offset = new Vector3(50, 0, 0);
    Image first, second, third, firstIcon, secondIcon, thirdIcon;
    PointerEventData.InputButton clickedButton;

    [Serializable]
    public class SlotData
    {
        public float x, y, z;
        public int siblingIndex;
        public Inventory.InventoryItem item;

        public SlotData(float x, float y, float z, int siblingIndex, Inventory.InventoryItem item)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.siblingIndex = siblingIndex;
            this.item = item;
        }
    }

    void Start()
    {
        //rl = GameObject.FindGameObjectWithTag("loader").GetComponent<ResourceLoader>();
    }
    void Update()
    {
        if (hovered)
        {
            tooltip.transform.position = Input.mousePosition + offset;
        }
    }

    public void SetActive()
    {
        
        
    }


    public void OnMouseEnter()
    {
        if (item != null && !dragging)
        {
            DisplayTooltip();
        }
    }

    void DisplayTooltip()
    {
        text = tooltip.GetComponentsInChildren<Text>();
        text[0].text = Regex.Replace(item.item.name, "_", " ");
        //text[1].text = item.flavorText;
        //text[2].text = item.attributes;
        tooltip.GetComponent<CanvasGroup>().alpha = 1;
        hovered = true;
    }

    public void OnMouseExit()
    {
        tooltip.GetComponent<CanvasGroup>().alpha = 0;
        hovered = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragging) { return; }
        clickedButton = eventData.button;
        temp = transform.localPosition;
        startingParent = transform.parent;
        index = transform.GetSiblingIndex();
        canvas = transform.parent.parent.transform;
        transform.SetParent(canvas);
        tooltip.GetComponent<CanvasGroup>().alpha = 0;
        dragging = true;
        triedBrewing = false;
        canvas.GetComponent<Canvas>().sortingOrder = 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragging)
        {
            transform.position = Input.mousePosition;
        }
    }

   

    void ResetDrag()
    {
        transform.SetParent(startingParent);
        transform.localPosition = temp;
        transform.SetSiblingIndex(index);
        tooltip.GetComponent<CanvasGroup>().alpha = 0;
        dragging = false;
        hovered = false;
    }
}
