using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player2D : PlayerBase
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool is2D;
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier = 2.5f; // Multiplier for a faster fall
    [SerializeField] private float lowJumpMultiplier = 2f; // Multiplier for a snappier low jump
    [Space]
    [SerializeField] private Rigidbody rb;

    [Header("GroundCheck")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private Vector3 groundCheckBoxSize;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ModifyJump(); // Adjust the fall and jump arc
        Movement();
    }

    private void Update()
    {
        GroundCheck();
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && isActive)
        {
            Jump();
        }
        if (isActive)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
        }
    }
    public override void Activate(bool isActive)
    {
        if (isActive)
        {  
            rb.constraints &= ~RigidbodyConstraints.FreezePosition;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        }else{
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        }
        base.Activate(isActive);
    }

    public override void Movement()
    {
        Vector3 normalizedDirection = direction.normalized * movementSpeed;
        rb.velocity = new Vector3(normalizedDirection.x, rb.velocity.y, rb.velocity.y);
        base.Movement();
    }

    private void Jump()
    {
        Debug.Log("Jump");
        // rb.velocity = new Vector3(rb.velocity.x, 0f); // Reset vertical velocity before applying jump force
        // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false;
    }

    private void ModifyJump()
    {
        if (rb.velocity.y < 0)
        {
            // Falling, so increase downward force
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            // Jumping, but the jump button is not held down, so increase downward force
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckBox(transform.position + groundCheckOffset, groundCheckBoxSize / 2, Quaternion.identity, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + groundCheckOffset, groundCheckBoxSize);
    }
}
