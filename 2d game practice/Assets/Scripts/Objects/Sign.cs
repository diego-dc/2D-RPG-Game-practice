using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteractableObjects
{
    
    [Header("TEXT related")]
    [SerializeField] private DialogController myDialogController;
    [SerializeField] private SignalSender signSignal;
    //reference to the string 
    [SerializeField] private StringValue signStringValueText;
    
    [SerializeField] private bool textActive = false;
    // reference to the tex
    [SerializeField] private string signText;

    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && PlayerInRange)
        {
            textActive = !textActive;
            signStringValueText.value = signText;
            myDialogController.stringValueText = signStringValueText;
            signSignal.Raise();
    
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if(other.CompareTag(otherTag) && !other.isTrigger)
        {
            if (textActive)
            {
                textActive = !textActive;
                signSignal.Raise();
            }
        }
    }
}

