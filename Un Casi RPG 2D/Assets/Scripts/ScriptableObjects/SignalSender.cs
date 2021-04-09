using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable Objects/Signals", fileName ="New Notification")]
public class SignalSender : ScriptableObject
{

    // we create a list of 'signal listeners'
    public List<SignalListener> listeners = new List <SignalListener>();

    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0 ; i --)
        {
            listeners[i].OnSignalRaised();
        }
    }

    // this will be to add stuff to the list
    public void RegisterListener(SignalListener listener)
    {
        if(!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    // this one to remove stuff from the list
    public void  DeRegisterListener(SignalListener listener)
    {
        if(listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
