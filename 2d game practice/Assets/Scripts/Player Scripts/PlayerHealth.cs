using UnityEngine;

public class PlayerHealth : Health
{

    [SerializeField] private FlashColor flash;
    [SerializeField] private FloatValue playerHealth;

    void Start()
    {
        this.SetHealth(playerHealth.value, playerHealth.value);
    }

    public void AddMaxHealth()
    {
        this.maxHealth += 1;
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        playerHealth.value = this.currentHealth;
        if(modifyHealthSignal)
        {
            this.modifyHealthSignal.Raise();
        }
        if(currentHealth > 0)
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
        
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
        playerHealth.value = this.currentHealth;
        if(modifyHealthSignal)
        {
            this.modifyHealthSignal.Raise();
        }
        
    }

    public override void Kill()
    {
        base.Kill();
        playerHealth.value = this.currentHealth;
        if(modifyHealthSignal)
        {
            this.modifyHealthSignal.Raise();
        }
    }

    public override void FullHeal()
    {
        base.FullHeal();
        playerHealth.value = this.currentHealth;
        if(modifyHealthSignal)
        {
            this.modifyHealthSignal.Raise();
        }
    }

    public void UseHealthPotion()
    {
        this.Heal(5);
    }


}
