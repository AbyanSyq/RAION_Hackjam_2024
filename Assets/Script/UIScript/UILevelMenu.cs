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
        for (int i = 0; i < System.Enum.GetValues(typeof(SceneData)).Length - 1; i++)
        {
            int levelIndex = i + 1;
            levelList[i].onClick.AddListener(() => ToLevelScene(levelIndex));
        }
    }

    void ToLevelScene(int n)
    {
        GameManager.instance.ChangeScene((SceneData)n);
        Debug.Log("Scene level menu"); 
    }


    void BackToMainMenu()
    {
        // Save data or other cleanup code if necessary
        UIManager.instance.ChangeUI(UI.MAINMENU);
        Debug.Log("Game has been exited."); // Ini hanya akan terlihat di editor.
    }
}
