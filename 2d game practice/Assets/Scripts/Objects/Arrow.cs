using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [Header("Arrow Variables")]
    public float speed;
    public Rigidbody2D myRigidbody;
    public float magicCost;

    [Header("Lifetime")]
    public float lifetime;


    // This function will determine the direction and speed our arrow will be thrown
    public void Setup(Vector2 velocity, Vector3 direction)
    {
        // this so it doesnt goes faster in some directions
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

    }

}
