using UnityEngine;

public class DamageOnContact : Damage
{
    [SerializeField] public string otherTag;
    [SerializeField] public int damageAmount;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Health temp = other.gameObject.GetComponent<Health>();
            if (temp)
            {
                ApplyDamage(temp, damageAmount);
            }
        }
    }
}
