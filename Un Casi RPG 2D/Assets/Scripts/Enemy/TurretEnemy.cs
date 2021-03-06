using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : ChasingEnemies
{

    [Header("Projectile")]
    public GameObject projectile;

    [Header("Fire Adjustments")]
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canFire = true;
    
    private void Update()
    {
        //We dont want our enemy to fire too many projectiles
        //we create a small delay.
        if(canFire == false)
        {
            fireDelaySeconds -= Time.deltaTime;
            if(fireDelaySeconds <= 0)
            {
                canFire = true;
                fireDelaySeconds = fireDelay;
            }
        }
        
    }
    
    public override void CheckDistance()
    {
        // In this case our chaseRadius would be like a detectionRadius for the turret
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance <= chaseRadius && targetDistance > attackRadius)
        {
            // this just for now, we could create a turret that is sleeping and wakes up, or something like that.
            if(myStateMachine.myState != GenericState.stun)
            {
                if(canFire)
                {
                    Vector2 tempVector = (Vector2)(target.position - transform.position);
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                    // this is also just temporary, just to notice when is active.
                    myStateMachine.ChangeState(GenericState.walk);
                    anim.SetAnimParameter("wakeUp", true);
                }
                
            }
            // if is not in the radius it can do another action.
        }else if(targetDistance > chaseRadius)
        {
            // add which action should do while is not chasing the player
            // ex: go back to sleeping.
            anim.SetAnimParameter("wakeUp", false);
        }
    }



}
