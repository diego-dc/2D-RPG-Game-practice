using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header("Movement")]
    public float move_speed;
    public Vector2 directionToMove;

    [Header("Object References")]
    public Rigidbody2D myRigidbody;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    public void Launch(Vector2 initialVel)
    {
        myRigidbody.velocity = initialVel * move_speed;
    }

}
