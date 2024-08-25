using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, ITransmitter
{
    public GameObject[] receivers;
    public void Transmit()
    {
        foreach (GameObject receiver in receivers)
        {
            receiver.GetComponent<IReceiver>()?.Receiver();
        }
    }   
    private void OnTriggerEnter(Collider other) {
        Debug.Log("press");
        Transmit();
    }
}
