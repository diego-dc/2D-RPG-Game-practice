using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Inventory", fileName ="New Inventory")]
public class Inventory : ScriptableObject
{

    [Header("Items")]
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public void AddItem(InventoryItem newItem)
    {
        // if its already in the inventory we increase its number
        if(isItemInInventory(newItem))
        {
            if(!newItem.isUnique)
            {
                newItem.numberHeld++;
            }
        }
        // if the item is not in the inventory we add it
        else
        {
            myInventory.Add(newItem);
            newItem.numberHeld++;
        }
    }

    public void RemoveItem(InventoryItem newItem)
    {
        // check if the item is in the inventory
        if (myInventory.Contains(newItem))
        {
            myInventory.Remove(newItem);
        }
    }

    public void UseItem(InventoryItem newItem)
    {
        // we check if we have the item
        if(myInventory.Contains(newItem))
        {
            // if the number is > 0
            if(newItem.numberHeld > 0)
            {
                // we sustract one from the amount of that item
                newItem.numberHeld--;
            }
        }
    }

    // This will check if we have an specific item to do allow us to do a certain action
    public bool isItemInInventory(InventoryItem newItem)
    {
        // true if it is, false if its not
        return myInventory.Contains(newItem);
    }

    public bool canUseItem(InventoryItem newItem)
    {
        // will tell use if there is the item your are trying to use or not
        return newItem.numberHeld > 0;
    }
    
}
