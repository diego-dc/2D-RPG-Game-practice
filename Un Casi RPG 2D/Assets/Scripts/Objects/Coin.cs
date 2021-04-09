using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{

    [SerializeField] private FloatValue MoneyToAddFloatValue;
    [SerializeField] private float MoneyToAdd;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //We change the amount of money we want to add in our FloatValue which will
            // be our messenger to tell the canvas
            MoneyToAddFloatValue.value = MoneyToAdd;
            powerUpSignal.Raise();
            //The coin has to dissapear once taken.
            Destroy(this.gameObject);
        }
    }
}
