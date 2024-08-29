using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : UIBase
{
    [SerializeField] Button ButtonRestart;
    [SerializeField] Button ButtonMainMenu;
    
    private void Awake()
    {
        ButtonRestart.onClick.AddListener(Restart);
        ButtonMainMenu.onClick.AddListener(ToMainMenu);
    }

    void Restart(){
        GameManager.instance.ReLoadScene();
    }

    void ToMainMenu()
    {
        GameManager.instance.ChangeScene(SceneData.MAINMENU);
        Debug.Log("Scene level menu"); 
    }
}
