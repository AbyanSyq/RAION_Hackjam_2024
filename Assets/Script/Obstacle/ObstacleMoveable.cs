using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveable : MultiDimentionBase
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
    public override void To2D()
    {
        rb.isKinematic = true;
    }
    public override void To3D()
    {
        rb.isKinematic = false;
    }
}
