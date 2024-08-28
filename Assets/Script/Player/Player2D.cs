using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;

public class Player2D : PlayerBase
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool is2D;
    [SerializeField] private GameObject aura;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color targetColor;
    [SerializeField] private float duration;
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
    [Header("Follow")]
    [SerializeField] private bool following;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ModifyJump(); // Adjust the fall and jump arc
        if (isActive)
        {  
            Movement();
        }
    }

    private void Update()
    {
        base.Update();
        SetAnimation();
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
    public void SetAnimation(){
        animator.SetFloat("Horizontal",math.abs(direction.x));
    }
    public override void Activate(bool isActive)
    {
        // if (isActive)
        // {  
        //     rb.constraints &= ~RigidbodyConstraints.FreezePosition;
        //     rb.constraints |= RigidbodyConstraints.FreezeRotation;
        // }else{
        //     rb.constraints = RigidbodyConstraints.FreezePositionX;
        //     rb.constraints |= RigidbodyConstraints.FreezeRotation;
        // }
        rb.isKinematic = !isActive;
        if (isActive)
        {
            spriteRenderer.DOColor(Color.white,duration);

            StartCoroutine(SetAura(false,0.5f));
        }else {
            spriteRenderer.DOColor(targetColor,duration);
            StartCoroutine(SetAura(true,0f));
        }
        base.Activate(isActive);
    }
    public IEnumerator SetAura(bool isActive, float delay){
        yield return new WaitForSeconds(delay);
        aura.SetActive(isActive);
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
        Collider[] colliders = Physics.OverlapBox(transform.position + groundCheckOffset, groundCheckBoxSize / 2, Quaternion.identity, groundLayerMask);
        isGrounded = colliders.Length > 0;

        Transform tempTransform = null;
        foreach (Collider collider in colliders)
        {
            if (!isActive && collider.CompareTag("MoveObject"))
            {
                if (tempTransform == null)
                {
                    tempTransform = collider.transform;
                    break;
                }
            }
        }
        if (tempTransform != null)
        {
            following = true;
        }else{
            following = false;
        }
        if (!isGrounded && !isActive || (following && isGrounded && !isActive) )
        {
            rb.isKinematic = false;
        }else if(!rb.isKinematic && !isActive){
            Activate(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + groundCheckOffset, groundCheckBoxSize);
    }
}
