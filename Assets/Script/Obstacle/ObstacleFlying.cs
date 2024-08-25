using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFlying : MultiDimentionBase, IReceiver
{
    public void Receiver()
    {
        Debug.Log(this.gameObject.name + " move ");
        transform.position = new Vector3(0, 0,0);
    }
}
