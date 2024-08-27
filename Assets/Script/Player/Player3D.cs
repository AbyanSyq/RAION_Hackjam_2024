using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : PlayerBase
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;
    [Space]
    [SerializeField] private Rigidbody rb;
    [Header("Push System")]
    [SerializeField] private LayerMask pushableLayerMask;
    [SerializeField] private Vector3 pushableCheckBoxSize;
    [SerializeField] private Transform pushableCeckTransform;
    [Space]
    [SerializeField] private bool isPushing = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        Movement();
    }
    private void Update() {
        GroundCheck();
        if (isActive)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
        }
    }
    public override void Movement()
    {
        Vector3 normalizedDirection = direction.normalized * movementSpeed;
        rb.velocity = new Vector3(normalizedDirection.x, rb.velocity.y, normalizedDirection.z);
        base.Movement();
    }
    private void GroundCheck()
    {
        isPushing = Physics.CheckBox(pushableCeckTransform.position, pushableCheckBoxSize, transform.rotation, pushableLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pushableCeckTransform.position, pushableCheckBoxSize);
    }
    
}
