using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockBack : MonoBehaviour
{

    [Header("Parameters for the knock back effect")]
    [SerializeField] private float knockStrength;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;
    //public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if we recognize the enemy or the player itself, so the script works for both sides,
        // when we hit them we make them experience a thrust.
        if(other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if(hit)
            {
                Vector2 direction = (hit.transform.position - transform.position);
                hit.DOMove((Vector2)other.transform.position + (direction.normalized * knockStrength), knockTime);
                //hit.AddForce(difference, ForceMode2D.Impulse);

            }
        }
    }

    
}
