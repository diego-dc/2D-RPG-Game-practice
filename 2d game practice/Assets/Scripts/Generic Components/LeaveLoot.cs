using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveLoot : MonoBehaviour
{

    [Header("Type of Loot")]
    public LootTable thisLoot;
    [SerializeField] private Health myHealth;
   
    void OnDisable()
    {
        // we have to check if is not getting disabled because of the application is quitting
        // in that case we cant leave loot or we will have an error, since the objects wont be destroyed
        if(myHealth.currentHealth <= 0)
        {
            MakeLoot();
        }
    }
    

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            PowerUp current = thisLoot.LootPower_up();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
