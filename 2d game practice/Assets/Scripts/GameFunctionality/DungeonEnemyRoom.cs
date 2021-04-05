using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : Room
{

    [Header("Room Doors")]
    public LockedDoor[] doors;

    [Header("Enemies")]
    [SerializeField] private Enemy[] enemies;



    // This will check if the enemies are alive or not, to open the doors or keep them close
    public void CheckEnemies()
    {
        for(int i = 0; i < enemies.Length; i ++)
        {
            if(enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
        }
        OpenDoors();
    }

    public void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }

    // To close all doors
    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i ++ )
        {
            doors[i].Close();
        }
    }

    // To open all doors
    public void OpenDoors()
    {
        for(int i = 0; i < doors.Length; i ++ )
        {
            doors[i].Open();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies and Doors once the player enters the room
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            CloseDoors();
            thisCamera.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies and pots once the player exits the room
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            thisCamera.SetActive(false);
        }
    }
}
