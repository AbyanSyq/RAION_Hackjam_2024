using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, ITransmitter
{
    public GameObject[] receivers;
    public void Transmit(bool press = true)
    {
        foreach (GameObject receiver in receivers)
        {
            receiver.GetComponent<IReceiver>()?.Receiver(press);
        }
    }   
    private void OnTriggerEnter(Collider other) {
        Debug.Log("press");
        Transmit();
    }
    private void OnTriggerExit(Collider other) {
        Debug.Log("release");
        Transmit(false);
    }
}
