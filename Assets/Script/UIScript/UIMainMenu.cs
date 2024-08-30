using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [SerializeField] Button ButtonStart;
    [SerializeField] Button ButtonLevelMenu;
    [SerializeField] Button ButtonExit;
    [SerializeField] Button ButtonReset;
    private void Awake()
    {
        ButtonStart.onClick.AddListener(StartGame);
        ButtonLevelMenu.onClick.AddListener(ToLevelMenu);
        ButtonExit.onClick.AddListener(ExitGame);
        ButtonReset.onClick.AddListener(ResetData);
    }

    void StartGame()
    {
        if (GameManager.instance == null)
        {
            Debug.Log("Lako null cok");
            return;
        }
        Debug.Log(GameManager.instance.GetLastLevel());
        GameManager.instance.ChangeScene(GameManager.instance.GetLastLevel());
    }

    void ToLevelMenu()
    {
        UIManager.instance.ChangeUI(UI.LEVELMENU);
        Debug.Log("Scene level menu"); 
    }

    void ExitGame()
    {
        // Save data or other cleanup code if necessary
        Application.Quit();
        Debug.Log("Game has been exited."); // Ini hanya akan terlihat di editor.
    }
    void ResetData(){
        SaveLoadSystem.ResetData(3);
    }
}
