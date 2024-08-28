using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
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
    [SerializeField] private float pushableCheckSphereRadius;
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
        base.Update();
        SetAnimation();
        GroundCheck();
        if (isActive)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
        }
    }
    public void SetAnimation(){
        animator.SetFloat("Horizontal",math.abs(direction.x));
        animator.SetFloat("Vertical",direction.z);

        animator.SetBool("isPushing",isPushing && (direction.x != 0 ||  direction.z != 0));
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
        isPushing = Physics.CheckSphere(pushableCeckTransform.position,pushableCheckSphereRadius,pushableLayerMask);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pushableCeckTransform.position, pushableCheckBoxSize);
        Gizmos.DrawWireSphere(pushableCeckTransform.position, pushableCheckSphereRadius);
    }
    
}
