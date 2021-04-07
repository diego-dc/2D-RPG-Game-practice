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
        Vector2 temp = (Vector2)(this.transform.position);
        myInitialPosition.resetPosition = temp;
    }
    void OnEnable()
    {
        
        myInitialPosition.ResetPosition();
    }


    void OnDisable()
    {
    }
}
