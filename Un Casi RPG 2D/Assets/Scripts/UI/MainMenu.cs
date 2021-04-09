using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private bool creditsOn = false;
    [SerializeField] private GameObject myGameObject;
    // Start is called before the first frame update
    void Start()
    {
        if(myGameObject)
        {
            myGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("CutScene House");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    public void Credits()
    {
    creditsOn = !creditsOn;
        if(creditsOn)
        {
            myGameObject.SetActive(true);
        }
        else{
            myGameObject.SetActive(false);
        }
    }
}
