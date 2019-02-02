using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public delegate void HoleReached();
    public event HoleReached OnHoleReached;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ball"))
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.velocity.magnitude == 0)
        {
            OnHoleReached?.Invoke();
        }
    }
}