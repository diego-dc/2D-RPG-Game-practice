using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedSwitchDoor : Door
{

    [SerializeField] private string myText;

    // Update is called once per frame
    void Update()
    {
        if(!isOpen && PlayerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                isTextActive = !isTextActive;
                myStringValue.value = myText;
                myDialogController.stringValueText = myStringValue;
                DialogSignal.Raise();
            }
        }
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
