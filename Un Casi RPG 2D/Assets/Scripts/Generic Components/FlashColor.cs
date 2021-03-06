using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    [SerializeField] private Sprite hitSprite;
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float flashDelay;
    [SerializeField] private Collider2D myTriggerCollider;
    private bool isFlashing = false;

    public void StartFlash()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashCo());
        }
    }

    public IEnumerator FlashCo()
    {
        isFlashing = true;
        myTriggerCollider.enabled = false;
        Sprite temp = mySprite.sprite;
        if(hitSprite){
            mySprite.sprite = hitSprite;
        }
        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (mySprite)
            {
                mySprite.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                mySprite.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
        }
        isFlashing = false;
        mySprite.sprite = temp;
        myTriggerCollider.enabled = true;
    }
}
