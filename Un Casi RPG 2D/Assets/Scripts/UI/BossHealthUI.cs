using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private Slider myHealthBar;
    [SerializeField] private EnemyHealth myHealth;

    void Start()
    {
        this.enabled = false;
        myHealthBar.maxValue  = myHealth.enemyHealth.value ;
        myHealthBar.value = myHealth.enemyHealth.value;
    }
        

    public void UpdateHealth()
    {
        myHealthBar.value = myHealth.currentHealth;
    }
}
