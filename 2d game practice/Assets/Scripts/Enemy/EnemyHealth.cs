using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    
    [SerializeField] private FloatValue enemyHealth;

    [Header("Signals")]
    [SerializeField] private SignalSender roomSignal;

    void OnEnable()
    {
        this.currentHealth = this.maxHealth;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.SetHealth(enemyHealth.value, enemyHealth.value);
    }

        // Update is called once per frame
    void Update()
    {
        
    }


    public override void Damage(float damage)
    {
        base.Damage(damage);
        if(currentHealth <= 0)
        {
            enemyDie();
        }
    }


    public void enemyDie()
    {
        base.Die();
        if(roomSignal)
            {
                roomSignal.Raise();
            }
    }

}
