﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    [Header("Signal")]
    public PowerUp thisLoot;

    [Header("Loot Variables")]
    public int lootChance;
}


[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    
    public Loot[] loots;


    public PowerUp LootPower_up()
    {
    //float or int
    int cumulativeProb = 0;
    int currentProb = Random.Range(0, 100);
    for(int i = 0; i < loots.Length; i++)
    {
        cumulativeProb += loots[i].lootChance;
        if(currentProb <= cumulativeProb)
        {
            return loots[i].thisLoot;
        }
    }

        return null;
    }
}
