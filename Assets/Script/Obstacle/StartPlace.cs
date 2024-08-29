using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlace : MonoBehaviour
{
    private bool isStarted = false;
    private void OnTriggerEnter(Collider other)
    {
        PlayerBase playerBase = other.GetComponent<PlayerBase>();

        if (playerBase != null && !isStarted)
        {
            StartGame();
            isStarted = true;
        }
    }

    private void StartGame()
    {
        Debug.Log("Game Start");
        UIManager.instance.GetUIGamePlay().StartStopwatch();
    }
}
