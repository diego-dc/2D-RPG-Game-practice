using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [Header("PauseMenu State")]
    [SerializeField] private bool isPaused = false;

    [Header("PauseMenu Variables")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private FloatValue gameSpeed;
    [SerializeField] private string mainMenuSceneString;

    
     // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Pause"))
        {
            ChangePauseValue();
        }
    }

    public void ChangePauseValue()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            gameSpeed.value = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            gameSpeed.value = 1f;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuSceneString);
    }
}
