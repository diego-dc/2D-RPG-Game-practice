using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemies : Movement
{

    [Header("Autofill")]
    public Transform target;

    [Header("Unity Objects References")]
    [SerializeField] public StateMachine myStateMachine;
    [SerializeField] public AnimatorController anim;
    [SerializeField] public string targetTag;

    [Header("Movement Variables")]
    public float chaseRadius;
    public float attackRadius;



    // Start is called before the first frame update
    void Start()
    {
    myStateMachine.myState = GenericState.idle;
    target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {   
        if(target)
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
                    Motion(temporary);
                    SetAnimation(temporary);
                    myStateMachine.ChangeState(GenericState.walk);
                }
            // if is not in the radius enemy can do another action.
            }else if(targetDistance > chaseRadius){
                // add which action should do while is not chasing the player
                // ex: go back to sleeping.
                Motion(Vector2.zero);
            }else if(targetDistance < attackRadius)
            {
                Motion(Vector2.zero);
            }
        }
    }
        


    //With this method we change the animation for each direction the enemy moves.
    public void SetAnimation(Vector2 tempMovement)
    {
        if (tempMovement.magnitude > 0)
        {
            anim.SetAnimParameter("MoveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("MoveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("Moving", true);
            myStateMachine.ChangeState(GenericState.walk);
        }
        else
        {
            anim.SetAnimParameter("Moving", false);
            if(myStateMachine.myState != GenericState.attack)
            {
                myStateMachine.ChangeState(GenericState.idle);
            }
        }
    }
}