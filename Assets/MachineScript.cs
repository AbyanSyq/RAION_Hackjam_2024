using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour,IReceiver
{
    public Animator animator;
    public int amountToPess = 1;
    public int pressed = 0;

    public void Receiver(bool press = true)
    {
        // isMoving = press; // Update the movement state based on the receiver's input
        if (press)
        {
            pressed++;
        }else{
            pressed--;
        }

        if (pressed >= amountToPess)
        {
            ShutDownMachine();
        }
    }
    public void ShutDownMachine(){
        SoundManager.Instance.PlaySound3D("MachineDown",transform.position);
    }
    public void DestroyMachine(){
        animator.Play("MachineDestroy");
        SoundManager.Instance.PlaySound3D("MachineDestroy",transform.position);
    }
}
