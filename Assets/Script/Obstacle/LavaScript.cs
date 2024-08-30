using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public bool isEffectTo2D = false;
    private void OnTriggerEnter(Collider other) {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LevelManager.instance.is2D)
            {
                if (isEffectTo2D)
                {
                    Debug.Log("Gameoverrrrrrrrr");
                    UIManager.instance.ChangeUI(UI.GAMEOVER); 
                }
            }else{
                Debug.Log("Gameoverrrrrrrrr");
                UIManager.instance.ChangeUI(UI.GAMEOVER); 
            }
            
        }
    }
}
