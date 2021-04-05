using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : ChasingEnemies
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CheckDistance()
    {   
        // if the position of the enemy's target is within the chaseRadius
        // the enemy will start moving towards the target's position
        // We change the animation
        // And the state of the enemy in case this one was sleeping or in another state
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance <= chaseRadius && targetDistance > attackRadius)
        {
            if(myStateMachine.myState != GenericState.stun)
            {
                Vector2 temporary = (Vector2)(target.position - transform.position);
                this.SetAnimation(temporary);
                this.Motion(temporary);
                myStateMachine.ChangeState(GenericState.walk);
                anim.SetAnimParameter("Walking", true);
            }
            // if is within the attackRadius the enemy will attack
        }else if(targetDistance <= attackRadius)
        {
            if(myStateMachine.myState != GenericState.stun)
                {
                    StartCoroutine(AttackCo());
                }
        }
        //If is outside the chasing radius
        else{
            anim.SetAnimParameter("Walking", false);
        }
    }

    public IEnumerator AttackCo()
    {

        myStateMachine.ChangeState(GenericState.attack);
        anim.SetAnimParameter("Attack", true);
        yield return new WaitForSeconds(0.5f);
        myStateMachine.ChangeState(GenericState.walk);
        anim.SetAnimParameter("Attack", false);
        yield return new WaitForSeconds(1f);
    }
}
