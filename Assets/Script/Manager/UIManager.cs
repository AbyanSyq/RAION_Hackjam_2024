using UnityEngine;
public enum UI{
    GAMEPLAY,
    MAINMENU,
    LEVELMENU,
    PAUSE,
    SETTINGS,
    VICTORY,
    GAMEOVER,
}
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    
    [Header("Information")]
    public UI currentUI;

    [Header("UI Prefabs")]
    [SerializeField] private UIMainMenu mainMenuPrefabs;
    [SerializeField] private UILevelMenu levelMenuPrefabs;
    [SerializeField] private UIPauseMenu pauseMenuPrefabs;
    [SerializeField] private UIGameOver gameoverPrefabs;
    [SerializeField] private UIComplete completePrefabs;
    [SerializeField] private UIGamePlay gamePlayPrefabs;    

    [Header("UI")]
    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UILevelMenu levelMenu;
    [SerializeField] private UIPauseMenu pauseMenu;
    [SerializeField] private UIGameOver gameover;
    [SerializeField] private UIComplete complete;
    [SerializeField] private UIGamePlay gamePlay;    

    [Header("Atribut[Need To Set]")]
    public Transform parent;
    private void Awake() 
    {
        base.Awake();
        mainMenu = Instantiate(mainMenuPrefabs,parent); mainMenu.Hide();
        levelMenu = Instantiate(levelMenuPrefabs, parent); levelMenu.Hide();
        pauseMenu = Instantiate(pauseMenuPrefabs,parent); pauseMenu.Hide();
        gameover = Instantiate(gameoverPrefabs,parent); gameover.Hide();
        complete = Instantiate(completePrefabs,parent); complete.Hide();
        gamePlay = Instantiate(gamePlayPrefabs,parent); gamePlay.Hide();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && (currentUI == UI.GAMEPLAY || currentUI == UI.PAUSE)){
            Debug.Log("escape");
            if(currentUI == UI.PAUSE) {
                ChangeUI(UI.GAMEPLAY);
            }
            else {
                ChangeUI(UI.PAUSE);
            }
        }
    }
    public void ChangeUI(UI toUI)
    {
        ShowUI(toUI);
        if (currentUI != toUI){
            HideUI(currentUI);
        }
        if (toUI == UI.PAUSE)
        {
            GameManager.instance.PauseGame(true);
        }else{
            GameManager.instance.PauseGame(false);
        }
        if (toUI == UI.VICTORY)
        {
            complete.SetCurrentRecord(gamePlay.StopStopwatch());
        }
        currentUI = toUI;
    }
    public void ShowUI(UI toUI)
    {
        switch (toUI)
        {
            case UI.GAMEPLAY:
                gamePlay.Show();
                break;
            case UI.MAINMENU:
                mainMenu.Show();
                break;
            case UI.LEVELMENU:
                levelMenu.Show();
                break;
            case UI.PAUSE:
                pauseMenu.Show();
                // GameManager.instance.PauseGame();
                break;
            case UI.SETTINGS:
                // UISettings.Show();
                break;
            case UI.VICTORY:
                complete.Show();
                // UIGameover.Show();
                break;
            case UI.GAMEOVER:
                gameover.Show();
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
        switch (toUI)
        {
            case UI.GAMEPLAY:
                gamePlay.Hide();
                break;
            case UI.MAINMENU:
                mainMenu.Hide();
                break;
            case UI.LEVELMENU:
                levelMenu.Hide();
                break;
            case UI.PAUSE:
                pauseMenu.Hide();
                // GameManager.instance.PauseGame();
                break;
            case UI.SETTINGS:
                // UISettings.Show();
                break;
            case UI.VICTORY:
                complete.Hide();
                break;
            case UI.GAMEOVER:
                gameover.Hide();
                // UIGameover.Show();
                break;
            default:
                Debug.LogError("Default called in Change Menu " + toUI);
                break;
        }
    }
    public UIGamePlay GetUIGamePlay(){
        return gamePlay;
    }
    public UIComplete GetUIComplete(){
        return complete;
    }
}
