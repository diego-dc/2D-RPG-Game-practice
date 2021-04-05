using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign
{
    [Header("NPC private references")]
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    private bool isMoving;

    [Header("For Random Movement")]
    private float moveTimeSeconds;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;
    

    [Header("NPC Stats")]
    public float speed;
    public Collider2D bounds;
    

    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If we use Update method, since sign has already an Update method too, we can use virtual
        // and override plus base.NameOfTheMethod so it do whatever is on the update method of sign 
        // and also what is our NPC update method.


        // since we are using fixed Update here, they dont override.
        
        // if the NPC is moving 
        if(isMoving)
        {
            // We start discounting from his "moving time"
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0)
            {
                // Once his "moving Time" is 0, we reset his "moving time" and we stop our NPC
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
                
            }
            // If the player is not inRange he can move 
            if(!PlayerInRange)
            {
                Move();
            }
            
        }
        // anything else
        else
        {
            // we start discounting form the "waiting time"
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                // When he wants to move again, we also want our NPC to change direction
                ChooseDifferentDirection();
                // once the "waiting time" is 0, we start moving the NPC again 
                // we reset the waiting time for next time
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }

    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        // This is just so it doesn´t go to the same direction it was coming from
        while(temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        // we create the direction our NPC will move
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        // we move it just if its in the boundaries given.
        if(bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        // otherwise we change the direction
        else 
        {
            ChangeDirection();
        }
        
    }

    void ChangeDirection()
    {
        // Our NPC we will move only in 4 directions, up-down-right-left
        int direction = Random.Range(0,4);
        switch(direction)
        {
            case 0:
            //walking to the Right
                directionVector= Vector3.right;
                break;
            case 1:
            //walking Up
                directionVector = Vector3.up;
                break;
            case 2:
            //walking left
                directionVector = Vector3.left;
                break;
            case 3:
            //walking Down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        // we call the update animations.
        UpdateAnimation();
    }

    //We want our NPC to change direction when he collides with something 
    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }

    void UpdateAnimation()
    {
        // We update the animations
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }
}
