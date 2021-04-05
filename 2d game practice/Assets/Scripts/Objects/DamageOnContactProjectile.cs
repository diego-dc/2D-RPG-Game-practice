using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContactProjectile : DamageOnContact
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Health temp = other.gameObject.GetComponent<Health>();
            if (temp)
            {
                ApplyDamage(temp, damageAmount);
                Destroy(gameObject);
            }
        }
    }

}
