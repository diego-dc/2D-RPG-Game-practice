using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : StateMachine
{

    [Header("Enemy Stats")]
    public string enemyName;
    [SerializeField] private ResetToPosition myInitialPosition;
 

    void Start()
    {
    }
    void OnEnable()
    {
        myInitialPosition.ResetPosition();
    }


    void OnDisable()
    {
    }
}
