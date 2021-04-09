using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private StateMachine myState;
    [SerializeField] private Inventory playerInventory;

    [Header("Magic Related")]
    [SerializeField] private FloatValue myMagic;
    [SerializeField] private FloatValue MagicToModify;
    [SerializeField] private SignalSender mySignal;
    

    [Header("Projectile Stuff")]
    [SerializeField] private Arrow arrow;
    [SerializeField] private InventoryItem bow;

    public IEnumerator SecondAttackCo()
    {
        //animator.SetBool("attacking", true);
        myState.ChangeState(GenericState.attack);
        yield return null;
        MakeArrow();
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (myState.myState != GenericState.interact)
        {
            myState.ChangeState(GenericState.walk);
        }
    }


    private void MakeArrow()
    {
        if (myMagic.value - MagicToModify.value  >= 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
            Arrow arrowInGame = Instantiate(arrow, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrowInGame.Setup(temp, ChooseArrowDirection());
            MagicToModify.value = arrow.magicCost;
            mySignal.Raise();
        }
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("MoveY"), animator.GetFloat("MoveX"))* Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    public bool CanUseArrow()
    {
        return playerInventory.isItemInInventory(bow);
    }
}
