using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/Generic Ability", fileName = "New Generic Ability")]
public class GenericAbility : ScriptableObject
{
    public virtual void Ability(Vector2 playerPosition, Vector2 playerFacingDirection,
                        Animator playerAnimator, Rigidbody2D playerRigidbody = null)
    {
        
    }

}