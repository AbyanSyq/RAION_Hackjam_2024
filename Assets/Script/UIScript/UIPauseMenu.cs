using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : UIBase
{
    [SerializeField] Button ButtonPause;
    [SerializeField] Button ButtonMainMenu;
    [SerializeField] Button ButtonExit;
    private void Awake()
    {
        ButtonPause.onClick.AddListener(ResumeGame);
        ButtonMainMenu.onClick.AddListener(ToMainMenu);
        ButtonExit.onClick.AddListener(ExitGame);
    }

    void ResumeGame()
    {
        UIManager.instance.ChangeUI(UI.GAMEPLAY);
    }

    void ToMainMenu()
    {
        GameManager.instance.ChangeScene(SceneData.MAINMENU);
        Debug.Log("Scene level menu"); 
    }

    void ExitGame()
    {
        // Save data or other cleanup code if necessary
        Application.Quit();
        Debug.Log("Game has been exited."); // Ini hanya akan terlihat di editor.
    }
}
