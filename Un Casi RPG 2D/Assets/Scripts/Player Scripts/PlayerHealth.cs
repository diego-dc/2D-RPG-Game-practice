using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{

    [SerializeField] private YouDiedMenu myDeadMenu;
    [SerializeField] private FlashColor flash;
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private FloatValue playerMaxHealth;

    void Start()
    {
        this.SetHealth(playerHealth.value, playerMaxHealth.value);
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
        }else
        {
            this.Die();
            myDeadMenu.ChangeDeadMenuValue();
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
