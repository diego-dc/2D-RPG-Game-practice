using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp
{

    [Header("PLayer Health Info")]
    public FloatValue heartContainers;
    public FloatValue myPlayerMaxHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            // We add one heart Container to the amount on Runtime 
            heartContainers.value += 1;
            // We do the same for our player maxHealth
            myPlayerMaxHealth.value += 1;
            // We add to the player's health what the new heartcontainer represent
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }

}
