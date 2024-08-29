using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveable : MultiDimentionBase
{
    public Rigidbody rb;
    public float soundDelay = 0.8f;
    private bool is2D;
    private bool isPushed;
    public float lastPlaySound = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
    private void Update() {
        if ((Time.time - lastPlaySound)> soundDelay && !is2D && isPushed)
        {
            if (rb.velocity != Vector3.zero)
            {
                Debug.Log("play");
                SoundManager.Instance.PlaySound3D("BoxPush",transform.position);
                lastPlaySound = Time.time;
            }
        }
        
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
            if (other.gameObject.CompareTag("Player"))
            {
                isPushed = true;
            }
            isPushed = true;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        } 
    }
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPushed = false;
            }
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rb.constraints |= RigidbodyConstraints.FreezeRotation;
        }
    }
}
