using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityForce = 100f;
    [SerializeField] private Rigidbody2D gravityTarget;
    private float gravityWellSize;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody != null)
        {
            gravityTarget = collision.attachedRigidbody;
            gravityWellSize = collision.bounds.size.x;
        }

    }

    private void FixedUpdate()
    {
        if (gravityTarget == null) return;

        Vector2 forceVector = gravityTarget.position - (Vector2)transform.position;
        body.AddForce(forceVector.normalized * gravityForce);
    }
}
