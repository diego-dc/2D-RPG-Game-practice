using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{

    [Header("Scene Related")]
    // This will be the Scene we want the player goes to
    public string sceneToLoad;

    [Header("Interaction with Player")]
    // we create a vector to indicate where the player should appear in the other scene
    public Vector2 playerPosition;
    public VectorValue startPositionInRoom;

    [Header("Transition effects")]
    // reference to the scene transition fade from white
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    private float PanelDuration = 1f;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, PanelDuration);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if(startPositionInRoom)
            {
                startPositionInRoom.value = playerPosition;
            }
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null) 
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        // 
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
