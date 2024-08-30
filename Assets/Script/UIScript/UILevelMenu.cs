using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelMenu : UIBase
{
    [SerializeField] private Button backToMainMenu;
    [SerializeField] private List<Button> levelList;
    private void Awake()
    {
        backToMainMenu.onClick.AddListener(BackToMainMenu);;
        for (int i = 0; i < levelList.Count; i++)
        {
            int levelIndex = i + 1;
            Debug.Log((SceneData)levelIndex);
            levelList[i].onClick.AddListener(() => ToLevelScene(levelIndex));
        }
    }

    void ToLevelScene(int n)
    {
        Debug.Log("Scene level menu"); 
        GameManager.instance.ChangeScene((SceneData)n);
    }


    void BackToMainMenu()
    {
        // Save data or other cleanup code if necessary
        UIManager.instance.ChangeUI(UI.MAINMENU);
        Debug.Log("Game has been exited."); // Ini hanya akan terlihat di editor.
    }
}
