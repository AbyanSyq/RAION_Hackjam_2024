using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player") && !LevelManager.instance.is2D)
        {
            Debug.Log("Gameoverrrrrrrrr");
            UIManager.instance.ChangeUI(UI.GAMEOVER);
        }
    }
}
