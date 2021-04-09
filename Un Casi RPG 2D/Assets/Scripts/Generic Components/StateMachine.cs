using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This give us the chance to have somekind of a boolean with as many states as we want.
// We will use it to know in which state our player or anything is when coding
public enum GenericState
{
    idle,
    walk,
    attack,
    stun,
    dead,
    interact
}

public class StateMachine : MonoBehaviour
{
    public GenericState myState;

    public void ChangeState(GenericState newState)
    {
        if(myState != newState)
        {
            myState = newState;
        }
    }
}
