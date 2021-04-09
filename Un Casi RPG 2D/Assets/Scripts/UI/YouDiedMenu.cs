using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedMenu : MonoBehaviour
{
       [Header("YouDiedMenu State")]
    [SerializeField] private bool isDead = false;

    [Header("YouDiedMenu Variables")]
    [SerializeField] private GameObject youDiedMenu;
    [SerializeField] private FloatValue gameSpeed;
    [SerializeField] private string mainMenuSceneString;

    
     // Start is called before the first frame update
    void Start()
    {
        youDiedMenu.SetActive(false);
    }



    public void ChangeDeadMenuValue()
    {
        isDead = !isDead;
        if (isDead)
        {
            youDiedMenu.SetActive(true);
            gameSpeed.value = 0f;
        }
        else
        {
            youDiedMenu.SetActive(false);
            gameSpeed.value = 1f;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuSceneString);
    }
}
