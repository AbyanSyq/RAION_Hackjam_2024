using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player2D : PlayerBase
{
    [Header("Jump")]
    public float jumpForce;

    private void FixedUpdate() {
        Movement();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
    }

    public override void Movement()
    {
        base.Movement();
        if (isActive)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            
        }

        transform.position += direction * Time.fixedDeltaTime * 10;
    }
    void Jump()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
    }
}
