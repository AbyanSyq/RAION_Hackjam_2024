using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DEvent : MonoBehaviour
{
    public void PlayerWalk(){
        SoundManager.Instance.PlaySound3D("Player2DWalk",transform.position);
    }
}
