using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveable : MultiDimentionBase
{
    public Rigidbody rb;
    private bool is2D;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
    public override void To2D()
    {
        // rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rb.constraints |= RigidbodyConstraints.FreezeRotation;
        is2D = true;
    }
    public override void To3D()
    {
        // rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rb.constraints |= RigidbodyConstraints.FreezeRotation;
        is2D = false;
    }
    private void OnCollisionEnter(Collision other) {
        if (!is2D && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle")))
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        } 
    }
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        }
    }
}
