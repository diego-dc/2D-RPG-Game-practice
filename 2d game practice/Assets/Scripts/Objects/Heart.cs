using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{

    [Header("Heart Variables")]
    public float amountToHeal;

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
        if (other.gameObject.CompareTag("Player") && other.isTrigger)
        {
            Health temp = other.gameObject.GetComponent<Health>();
            if (temp)
            {
                temp.Heal(amountToHeal);
            }
            Destroy(this.gameObject);
        }
    }
}
