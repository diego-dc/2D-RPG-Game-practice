using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCoinDoor : Door
{
    [Header("Door Coin variables")]
    [SerializeField] private FloatValue myMoney;
    [SerializeField] private float CoinsNecessary;
    [SerializeField] private string myText;

    // Update is called once per frame
    void Update()
    {
        if(!isOpen && PlayerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                //If the player has a key we call the open method
                if (PlayerHasEnoughMoney(CoinsNecessary))
                {
                    Open();
                }
                else
                {
                    isTextActive = !isTextActive;
                    signStringValueText.value = myText;
                    DialogSignal.Raise();
                }
            }
        }
    }


    bool PlayerHasEnoughMoney(float money)
    {
        return myMoney.value >= money;
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
            if (!isOpen)
            {
                mySignal.Raise();
            }
        }
    }
}
