using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [Header("Respawns on the room")]
    [SerializeField] private GameObject[] respawnObjects;


    [Header("Virtual Camera")]
    public GameObject thisCamera;

    [Header("Room Variables")]
    [SerializeField] private string roomName;
    [SerializeField] private StringValue roomNameHolder;
    [SerializeField] private SignalSender roomSignal;
    [SerializeField] private string playerTag;

    void Start()
    {
        this.DespawnObjects();
    }



    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(playerTag) && !other.isTrigger)
        {
            thisCamera.SetActive(true);
            roomNameHolder.value = roomName;
            roomSignal.Raise();
            RespawnObjects();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(playerTag) && !other.isTrigger)
        {
            thisCamera.SetActive(false);
            DespawnObjects();
        }
    }

    public void RespawnObjects()
    {
         //Activate all enemies and pots once the player enters the room
        for(int i = 0; i < respawnObjects.Length; i++)
        {
            // we will change the activation state of each gameobject 
            respawnObjects[i].SetActive(true);
            // we get their health reference
            Health temp = respawnObjects[i].GetComponentInChildren<Health>();
            // we set all their health to max
            if (temp)
            {
                temp.FullHeal();
            }
            ResetToPosition reset = respawnObjects[i].GetComponent<ResetToPosition>();
            if (reset)
            {
                reset.ResetPosition();
            }
        }
        
    }

    public void DespawnObjects()
    {
        //Desactivate all gameobjects 
        for(int i = 0; i < respawnObjects.Length; i++)
        {
            respawnObjects[i].SetActive(false);
        }
    }

}
