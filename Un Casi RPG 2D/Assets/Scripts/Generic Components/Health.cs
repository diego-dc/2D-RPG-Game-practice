using UnityEngine;

/*
 * This script is a generic health component for
 * any item that needs to have health.  This can
 * be added to the player, enemies, pots or grass
 * in the scene.  It can also be extended by
 * inheriting from it for specific interactions desired.
 */
 
public class Health : MonoBehaviour
{
    [Tooltip("Max and current health \n Set this to one for pots")]
    [Header("Health values")]
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;

    [Header("Update Object Health Signal")]
    [SerializeField] public SignalSender modifyHealthSignal;

    [Header("Dead Related")]
    [SerializeField] public GameObject deathEffect;

    public void SetHealth(float amount, float maxhealth)
    {
        currentHealth = amount;
        maxHealth += maxhealth;
    }

    public virtual void Damage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0){
            currentHealth = 0;
        }
    }

    public virtual void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Kill()
    {
        currentHealth = 0;
    }

    public virtual void FullHeal()
    {
        currentHealth = maxHealth;
    }

    public virtual void Die()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        this.transform.parent.gameObject.SetActive(false);
    }
}
