using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Scriptable Objects/Bool Value", fileName = "New Bool Value")]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    public bool value;

    [SerializeField] private bool resetValue;

    private void OnEnable()
    {
        value = resetValue;
    }

}
