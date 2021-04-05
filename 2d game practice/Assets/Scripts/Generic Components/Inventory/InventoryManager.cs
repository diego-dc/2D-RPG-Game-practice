using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public Inventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject InventoryPanelScroll;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;



    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }


    public void SetTextAndButton(string description, bool buttonActive)
    {
        // we change the description text of our inventory UI to our selected item's description
        descriptionText.text = description;
        // if its necessary to display the 'use' button we activate it
        if(buttonActive)
        {
            useButton.SetActive(true);
        }else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        // if there is a player inventory
        if(playerInventory)
        {
            // we go through all items in the inventory, and if they exist we create a slot
            // in the inventory for that item.
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if(playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = 
                        Instantiate(blankInventorySlot, InventoryPanelScroll.transform.position, Quaternion.identity);
                    
                    temp.transform.SetParent(InventoryPanelScroll.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if(newSlot)
                    {                
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }



    public void SetupDescriptionAndButton(InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newItem.itemDescription;
        useButton.SetActive(newItem.isUsable);
    }


    void ClearInventorySlots()
    {
        for(int i = 0; i < InventoryPanelScroll.transform.childCount; i++)
        {
            Destroy(InventoryPanelScroll.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if(currentItem)
        {
            // we use the item
            //currentItem.Use();
            // clear all of the inentory slots
            ClearInventorySlots();
            // refill all slots with new numbers
            MakeInventorySlots();
            if(currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
            
        }
    }
}
