using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIComplete : UIBase
{
    [SerializeField] Button ButtonNext;
    [SerializeField] Button ButtonMainMenu;
    
    private void Awake()
    {
        ButtonNext.onClick.AddListener(NextScene);
        ButtonMainMenu.onClick.AddListener(ToMainMenu);
    }

    void NextScene(){
        GameManager.instance.ChangeScene(GameManager.instance.currentScene + 1);
    }

    void ToMainMenu()
    {
        GameManager.instance.ChangeScene(SceneData.MAINMENU);
        Debug.Log("Scene level menu"); 
    }
}
