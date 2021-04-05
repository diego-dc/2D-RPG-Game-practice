using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObjects
{
    [Header("Door variables")]
    public bool isOpen;
    public BoolValue isOpenValue;
    public SpriteRenderer doorSprite;
    public Collider2D doorCollider;

    [Header("Text Related")]
    public bool isTextActive = false;
    public StringValue signStringValueText;
    public SignalSender DialogSignal;


    // Start is called before the first frame update
    public virtual void Start()
    {
        isOpen = isOpenValue.value;
    }


    public virtual void Close()
    {
        // set open to false
        isOpen = false;
        //Should activate the door idle
        //or we can just turn on the sprite renderer
        doorSprite.enabled = true;
        //And we turn on the boxcollider
        doorCollider.enabled = true;
    }

    public virtual void Open()
    {
        // set open to true
        isOpen = true;
        //Should activate an animation
        //or we can just turn off the sprite renderer
        doorSprite.enabled = false;
        //And we turn off the boxcollider
        doorCollider.enabled = false;
    }

}