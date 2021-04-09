using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [Header("UI Related")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("item's Variables")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;
    

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        // if the item is not null we want to give the sprite to the UI so it can be displayed
        if(thisItem)
        {
            itemImage.sprite = thisItem.itemSprite;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    // for when the button is pressed
    public void ClickedOn()
    {
        // if the item exists
        if(thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
