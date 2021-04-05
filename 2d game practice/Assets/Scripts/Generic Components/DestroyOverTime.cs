using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    [Header("Lifetime")]
    [SerializeField] private float lifetime;


    // Start is called before the first frame update
    void Start()
    {
        // After a certain amount of time, our objects will disappear
        // otherwise they could go on forever.
        Destroy(this.gameObject, lifetime);
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

