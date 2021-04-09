using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerup : PowerUp
{
    [SerializeField] private FloatValue myMagicFloatValue;
    [SerializeField] private float magicValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            myMagicFloatValue.value = this.magicValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }

}
