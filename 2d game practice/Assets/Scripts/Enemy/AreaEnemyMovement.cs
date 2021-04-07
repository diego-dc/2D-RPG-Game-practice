using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemyMovement : ChasingEnemies
{
    [Header("Boundaries")]
    public Collider2D boundary;

    public override void CheckDistance()
    {
        if(target)
        {
            // if the position of the enemy's target is within the chaseRadius
            // the enemy will start moving towards the target's position
            // We change the animation
            // And the state of the enemy in case this one was sleeping or in another state
            float targetDistance = Vector3.Distance(transform.position, target.position);
            if(targetDistance > attackRadius && boundary.bounds.Contains(target.transform.position))
            {
                if(myStateMachine.myState != GenericState.stun)
                {
                    Vector2 temporary = (Vector2)(target.position - transform.position);
                    Motion(temporary);
                    SetAnimation(temporary);
                    myStateMachine.ChangeState(GenericState.walk);
                    anim.SetAnimParameter("wakeUp", true);
                }
                // if is not in the radius it can do another action.
            }else if((boundary.bounds.Contains(target.transform.position)) == false)
            {
                anim.SetAnimParameter("wakeUp", false);
                Motion(Vector2.zero);
            }else if(Vector3.Distance(target.position, transform.position) < attackRadius)
            {
                Motion(Vector2.zero);
            }
        }
    }
        
}
