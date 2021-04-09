using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable Objects/Float Value", fileName ="New Float Value")]
public class FloatValue : ScriptableObject
{
    public float value;
    [SerializeField] private float defaultValue;

    private void OnEnable()
    {
        value = defaultValue;
    }
}


