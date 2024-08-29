using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DEvent : MonoBehaviour
{
    public void PlayerWalk(){
        SoundManager.Instance.PlaySound3D("Player3DWalk",transform.position);
    }
}
