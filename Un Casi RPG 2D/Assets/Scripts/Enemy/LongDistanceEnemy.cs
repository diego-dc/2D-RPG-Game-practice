using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceEnemy : ChasingEnemies
{

    [Header("If it is BOSS")]
    [SerializeField] private bool isBoss = false;
    [SerializeField] private GameObject myUI;

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
            if(isBoss)
            {
                myUI.SetActive(true);
            }
            // this just for now, we could create a turret that is sleeping and wakes up, or something like that.
            if(myStateMachine.myState != GenericState.stun)
            {
                
                    anim.SetAnimParameter("moving", true);
                    Vector2 temporary = (Vector2)(target.position - transform.position);
                    Motion(temporary);
                    SetAnimation(temporary);
                    myStateMachine.ChangeState(GenericState.walk);
                
            }
            // if is not in the radius it can do another action.
        }else if(targetDistance > chaseRadius)
        {
            if(isBoss)
            {
                myUI.SetActive(false);
            }
            // add which action should do while is not chasing the player
            // ex: go back to sleeping.
            Motion(Vector2.zero);
            anim.SetAnimParameter("moving", false);
        }
        else if(targetDistance < attackRadius)
        {
            Motion(Vector2.zero);
            if(canFire)
            {
                Vector2 tempVector = (Vector2)(target.position - transform.position);
                GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                current.GetComponent<Projectile>().Launch(tempVector);
                canFire = false;
            }
        }
    }



}
