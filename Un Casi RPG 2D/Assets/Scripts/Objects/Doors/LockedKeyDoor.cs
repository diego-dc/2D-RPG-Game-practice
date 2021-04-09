using UnityEngine;


public class LockedKeyDoor : Door
{
    [Header("Door Key variables")]
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventoryItem keyitem;

    [SerializeField] private string myText;

    // Update is called once per frame
    void Update()
    {
        if(!isOpen && PlayerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                //If the player has a key we call the open method
                if (PlayerHasKey())
                {
                    //remove a key from the player ans call Open method
                    playerInventory.UseItem(keyitem);
                    Open();
                }
                else
                {
                    isTextActive = !isTextActive;
                    myStringValue.value = myText;
                    myDialogController.stringValueText = myStringValue;
                    DialogSignal.Raise();
                }
            }
        }
    }


    bool PlayerHasKey()
    {
        return playerInventory.canUseItem(keyitem);
    }

    public override void Open()
    {
        base.Open();
        mySignal.Raise();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            PlayerInRange = true;
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            PlayerInRange = false;
            if(isTextActive)
            {
                isTextActive = !isTextActive;
                DialogSignal.Raise();
            }
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }

}
