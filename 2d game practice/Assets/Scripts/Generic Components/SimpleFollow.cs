using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : Movement
{

    [SerializeField] private string targetTag;
    private Transform target;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float interactionRadius;
    private float targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance < chaseRadius && targetDistance > interactionRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            Motion(temp);
        }
    }

    // this just for debugging purposes 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}