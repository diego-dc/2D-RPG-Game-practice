using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    
    [Header("InventoryMenu State")]
    [SerializeField] private bool LookingInventory = false;

    [Header("InventoryMenu Variables")]
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private FloatValue gameSpeed;


    
     // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Inventory"))
        {
            ChangeInventoryMenuValue();
        }
    }

    void ChangeInventoryMenuValue()
    {
        LookingInventory = !LookingInventory;
        if (LookingInventory)
        {
            inventoryMenu.SetActive(true);
            gameSpeed.value = 0f;
        }
        else
        {
            inventoryMenu.SetActive(false);
            gameSpeed.value = 1f;
        }
    }


    public void BackToWorldViewButton()
    {
        ChangeInventoryMenuValue();
    }
}
