using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : UIBase
{
    [SerializeField] Button ButtonResume;
    [SerializeField] Button ButtonRestart;
    [SerializeField] Button ButtonMainMenu;
    [SerializeField] Button ButtonExit;
    private void Awake()
    {
        ButtonResume.onClick.AddListener(ResumeGame);
        ButtonRestart.onClick.AddListener(Restart);
        ButtonMainMenu.onClick.AddListener(ToMainMenu);
        ButtonExit.onClick.AddListener(ExitGame);
    }

    void ResumeGame()
    {
        UIManager.instance.ChangeUI(UI.GAMEPLAY);
    }
    void Restart(){
        GameManager.instance.ReLoadScene();
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
