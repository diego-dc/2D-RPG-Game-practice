using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [Header("Switch State variables")]
    [SerializeField] private bool active;
    public BoolValue storedValue;

    [Header("Animation and Sprites")]
    public Sprite activeSprite;
    private SpriteRenderer mySprite;

    public LockedSwitchDoor thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.value;
        if(active)
        {
            ActivateSwitch();
        }
        
    }

    // this function will change the values of our variables to open the door.
    public void ActivateSwitch()
    {
        active = true;
        storedValue.value = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //is it the player?
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if(active == false)
            {
                //if it is the player we open the door.
                ActivateSwitch();
            }
        }
        
    }
}
