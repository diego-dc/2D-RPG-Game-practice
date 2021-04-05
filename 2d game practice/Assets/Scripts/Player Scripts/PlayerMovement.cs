using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : Movement
{

    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private float WeaponAttackDuration;
    [SerializeField] private ReceiveItem myItem;

    private Vector2 tempMovement = Vector2.down;
    [SerializeField] private BowAttack myBowAttack;


    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 60; <-- this could help to use Update instead of fixed Update.
        //when we start Player is in idle state
        myState.ChangeState(GenericState.idle);
    }

    // Update is called once per frame
    void Update()
    {
        //If our player is busy receiving an item, wont receive other calls
        if(myState.myState == GenericState.interact )
        {
            
            if(Input.GetButtonDown("Submit") )
            {
                myState.ChangeState(GenericState.idle);
                anim.SetAnimParameter("receiveItem", false);
                myItem.ChangeSpriteState();
            }
            return;
        }
        GetInput();
        SetAnimation();
    }

    // We use movement in FixedUpdate bc in Update-one per frame goes extremelly slow, better use inputs there
    void FixedUpdate()
    {
    }

    void SetState(GenericState newState)
    {
        myState.ChangeState(newState);
    }


    void GetInput()
    {
        if(Input.GetButtonDown("PrimaryWeapon"))
        {
            StartCoroutine(WeaponCo());
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
        else if (Input.GetButtonDown("SecondaryWeapon") && myState.myState != GenericState.attack
           && myState.myState != GenericState.stun)
        {
            if (myBowAttack.CanUseArrow())
            {
                StartCoroutine(myBowAttack.SecondAttackCo());
            }
        }
        else if (myState.myState != GenericState.attack)
        {
            tempMovement.x = Input.GetAxisRaw("Horizontal");
            tempMovement.y = Input.GetAxisRaw("Vertical");
            Motion(tempMovement);
        }
        
        else
        {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
    }

    void SetAnimation()
    {
        if (tempMovement.magnitude > 0)
        {
            anim.SetAnimParameter("MoveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("MoveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("Moving", true);
            SetState(GenericState.walk);
        }
        else
        {
            anim.SetAnimParameter("Moving", false);
            if(myState.myState != GenericState.attack)
            {
                SetState(GenericState.idle);
            }
        }
    }
    
    public IEnumerator WeaponCo()
    {
        myState.ChangeState(GenericState.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(WeaponAttackDuration);
        myState.ChangeState(GenericState.idle);
        anim.SetAnimParameter("attacking", false);
    }
}
