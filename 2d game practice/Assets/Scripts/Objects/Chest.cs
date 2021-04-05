using UnityEngine;
using UnityEngine.UI;


public class Chest : InteractableObjects
{

    [Header("Items and Inventory")]
    [SerializeField] private InventoryItem myItem;
    [SerializeField] private Inventory playerInventory;

    [Header("Chest State")]
    //to know if the chest is open
    [SerializeField] private bool isOpen = false;
    [SerializeField] private BoolValue openValue;

    [SerializeField] private SpriteValue spriteValue;
    [SerializeField] private StringValue itemString;

    [Header("Animation")]
    [SerializeField] private AnimatorController anim;
    [Header("ReceivedItem Signal")]
    [SerializeField] private SignalSender chestSignal;

    


    // Start is called before the first frame update
    void Start()
    {
        isOpen = openValue.value;
        // This is for when we re-enter the escene, we want our chest open if it was 
        // already open before we left the scene
        if(isOpen)
        {
            anim.SetAnimParameter("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && PlayerInRange)
        {
            if(isOpen)
            {
                // Chest is already Open
                return;
            }
            //Open the chest
            DisplayContents();
        }
    }
    public void DisplayContents()
    {
        //Set the chest to opened
        isOpen = !isOpen;
        //We set the boolean true for the animation 
        anim.SetAnimParameter("opened", true);
        openValue.value = isOpen;
        //Dialog window on - Dialog text = contents text.
        spriteValue.value = myItem.itemSprite;
        itemString.value = myItem.itemDescription;
        //Add contents to the inventory
        playerInventory.AddItem(myItem);
        // we send the signal to tell the player he received the item
        chestSignal.Raise();
        //Raise the signal to the player for the reaction to deactivate.
        mySignal.Raise();
    }

    public override void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
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
        if(other.CompareTag(otherTag) && !other.isTrigger)
        {
            PlayerInRange = false;
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }
}
