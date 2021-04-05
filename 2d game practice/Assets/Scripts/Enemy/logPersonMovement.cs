using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logPersonMovement : ChasingEnemies //communicates directly with our script ChasingEnemies.
{

    void FixedUpdate()
    {
        CheckDistance();
    }

    public override void CheckDistance() // Some Details in ChasingEnemies.cs
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            if(this.myStateMachine.myState != GenericState.stun)
            {

                Vector2 temporary = (Vector2)(target.position - transform.position);

                this.SetAnimation(temporary);
                this.Motion(temporary);
                myStateMachine.ChangeState(GenericState.walk);
                anim.SetAnimParameter("wakeUp", true);
            }
        }else if(targetDistance > chaseRadius){
            anim.SetAnimParameter("wakeUp", false);
            Motion(Vector2.zero);
        }else if(targetDistance < attackRadius)
        {
            Motion(Vector2.zero);
        }
    }
}
