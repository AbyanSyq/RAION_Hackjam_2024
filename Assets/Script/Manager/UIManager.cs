using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UI{
    GAMEPLAY,
    MAINMENU,
    PAUSE,
    SETTINGS,
    GAMEOVER,
}
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    
    [Header("Information")]
    public UI currentUI;

    [Header("UI Prefabs")]

    [Header("UI")]

    [Header("Atribut[Need To Set]")]
    public Transform parent;
    public void Start()//sementara pake Start nanti klo udh ada game manager bakal pake Init
    {
        
    }
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(currentUI == UI.PAUSE) {
                ChangeMenu(UI.GAMEPLAY);
                // GameManager.instance.ResumeGame();
            }
            else {
                ChangeMenu(UI.PAUSE);
            }
        }
    }
    public void ChangeMenu(UI toUI)
    {
        ShowUI(toUI);
        if (currentUI != toUI){
            HideUI(currentUI);
        }
        currentUI = toUI;
    }
    public void ShowUI(UI toUI)
    {
        // Debug.Log("show called" + toUI);    
        switch (toUI)
        {
            case UI.GAMEPLAY:
                break;
            case UI.MAINMENU:
                
                break;
            case UI.PAUSE:
                // UIPause.Show();
                // GameManager.instance.PauseGame();
                break;
            case UI.SETTINGS:
                // UISettings.Show();
                break;
            case UI.GAMEOVER:
                // UIGameover.Show();
                break;
            default:
                Debug.LogError("Default called in Change Menu " + toUI);
                break;
        }
        // Debug.Log("show Completed"); 
    }
    public void HideUI(UI toUI)
    {
        // Debug.Log("Hide :" + toUI);
        switch (toUI)
        {
            case UI.GAMEPLAY:
                break;
            case UI.MAINMENU:
                
                break;
            case UI.PAUSE:
                // UIPause.Show();
                // GameManager.instance.PauseGame();
                break;
            case UI.SETTINGS:
                // UISettings.Show();
                break;
            case UI.GAMEOVER:
                // UIGameover.Show();
                break;
            default:
                Debug.LogError("Default called in Change Menu " + toUI);
                break;
        }
    }
    
}
