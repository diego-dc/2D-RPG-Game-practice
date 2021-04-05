using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour
{
    [SerializeField] private StringValue myStringValue;
    [SerializeField] private DialogController myDialogController;
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private SpriteValue receivedSprite;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    public bool isActive = false;

    [Header("Dialog Stuff")]
    [SerializeField] private SignalSender dialogSignal;

    // Start is called before the first frame update
    void Start()
    {
        // we set the sprite desabled so is not in the game
        mySprite.enabled = false;
    }

    // this method will turn on or off the sprite of the item in the game
    // - SIGNAL REACTIVE -
    public void ChangeSpriteState()
    {
        isActive = !isActive;
        if (isActive)
        {
            DisplaySprite();
        }
        else
        {
            DisableSprite();
        }
    }

    // This method to raise the item.
    void DisplaySprite()
    {
        myState.ChangeState(GenericState.interact);
        myDialogController.stringValueText = myStringValue;
        mySprite.enabled = true;
        mySprite.sprite = receivedSprite.value;
        anim.SetAnimParameter("receiveItem", true);
        dialogSignal.Raise();
    }

    // this to come back to normal.
    void DisableSprite()
    {
        myState.ChangeState(GenericState.idle);
        mySprite.enabled = false;
        dialogSignal.Raise();

    }
}
