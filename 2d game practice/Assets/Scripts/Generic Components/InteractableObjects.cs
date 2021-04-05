using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{

    [Header("Player info")]
    //reference to know if dialog should be active or not
    [SerializeField] public bool PlayerInRange;

    [SerializeField] public string otherTag;

    [Header("Raction Signals")]
    // We will use this signals to turn on and off the contextClue on our player

	[SerializeField] public SignalSender mySignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag(otherTag) && !other.isTrigger)
        {
            PlayerInRange = true;
            mySignal.Raise();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(otherTag) && !other.isTrigger)
        {
            PlayerInRange = false;
            mySignal.Raise();
        }
    }
}
