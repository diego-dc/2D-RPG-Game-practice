using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyMovement : ChasingEnemies
{

    [Header("Patrolling path references")]
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    void Start()
    {
        myStateMachine.ChangeState(GenericState.walk);
    }

    public override void CheckDistance() // Some details in ChasingEnemies.cs
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance <= chaseRadius && targetDistance > attackRadius)
        {
            if(myStateMachine.myState != GenericState.stun)
            {
                Vector2 temporary = (Vector2)(target.position - transform.position);
                Motion(temporary);
                SetAnimation(temporary);
            }
        }else if(targetDistance > chaseRadius)
        {    
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector2 temporary = (Vector2)(path[currentPoint].position - transform.position);
                Motion(temporary);
                SetAnimation(temporary);
            }else{
                ChangeGoal();
            }
        }
        else if(targetDistance < attackRadius)
        {
            Motion(Vector2.zero);
        }
    }

    // With this we tell the enemy to go the next point on the path, and 
    // this way continue with the cicle.
    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0; 
            currentGoal = path [0];
        }else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

}
