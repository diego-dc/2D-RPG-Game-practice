using UnityEngine;

public class ContextClue : MonoBehaviour
{

    [Header("Context Clue variables")]
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private bool clueActive = false;

    // we sart with out context clue no visible
    public void start()
    {
        mySprite.enabled = false;
    }

    // this methdo activates witha signal, shows or hide our context signal
    // -SIGNAL REACTIVE-
    public void ChangeClue()
    {
        clueActive = !clueActive;
        mySprite.enabled = clueActive;
    }
    
}
