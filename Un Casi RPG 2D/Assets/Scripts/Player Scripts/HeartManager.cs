using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{

    [Header("UI variables")]
    [SerializeField] private Image[] hearts;

    // references for the three type of sprites we will be using (u can add more here)
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfFullHeart;
    [SerializeField] private Sprite emptyHeart;

    [Header("Player Health Info")]
    // a reference to know how many HeartContainers we have.
    [SerializeField] private FloatValue heartContainers;

    // a reference to know player's current health
    [SerializeField] private FloatValue playerCurrentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.value; i++)
        {
            if(i < hearts.Length)
            {
                hearts[i].gameObject.SetActive(true); // we activate the hearts on escene
                hearts[i].sprite = fullHeart; // we use the full heart sprite (image)
            }
        }
    }

    public void UpdateHearts()
    {
        // We check if there are new hearts to be added
        InitHearts();
        float tempHealth = playerCurrentHealth.value / 2;
        for (int i = 0; i < heartContainers.value; i++)
        {
            if( i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart; 
            }else if( i >= tempHealth) 
            {
                hearts[i].sprite = emptyHeart;
            }else
            {
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
