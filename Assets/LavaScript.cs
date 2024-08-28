using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gameoverrrrrrrrr");
            UIManager.instance.ChangeUI(UI.GAMEOVER);
        }
    }
}
