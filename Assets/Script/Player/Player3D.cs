using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : PlayerBase
{
    private void FixedUpdate() {
        Movement();
    }
    public override void Movement()
    {
        base.Movement();
        if (isActive)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
        }

        transform.position += direction * Time.fixedDeltaTime * 10;
    }
    
}
