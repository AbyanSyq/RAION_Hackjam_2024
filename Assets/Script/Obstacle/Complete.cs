using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public int FinishedCount = 0;
    public HashSet<PlayerBase> playersWhoFinished = new HashSet<PlayerBase>();

    private void OnTriggerEnter(Collider other)
    {
        PlayerBase playerBase = other.GetComponent<PlayerBase>();

        if (playerBase != null && !playersWhoFinished.Contains(playerBase))
        {
            FinishedCount++;
            playersWhoFinished.Add(playerBase);
            
            if (FinishedCount == 2) // Assuming there are two players
            {
                CompleteStage();
            }
        }
    }

    private void CompleteStage()
    {
        // Complete the stage
        Debug.Log("Stage Completed!");
        UIManager.instance.ChangeUI(UI.VICTORY);
    }
}
