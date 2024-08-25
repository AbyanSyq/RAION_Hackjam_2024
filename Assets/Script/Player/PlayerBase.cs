using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [Header("Movement")]
    public Vector3 direction;
    public bool isActive;
    public virtual void Movement(){

    }
    public virtual void Activate(bool isActive){
        direction = Vector3.zero;
        this.isActive = isActive;
    }
}
