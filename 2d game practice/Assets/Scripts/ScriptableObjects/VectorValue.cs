using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Vector Value", fileName ="New Vector Value")]
public class VectorValue : ScriptableObject
{

  [Header("Value Running in game")]
  public Vector2 value;

  [Header("Value by default when starting")]
  [SerializeField] private Vector2 defaultValue;

  public void OnEnable()
  {
      value = defaultValue;
  }

}
