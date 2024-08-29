using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneData{//NANTI SEUAIIN SAMA DI BUILD
    MAINMENU,
    LEVEL01,
    LEVEL02,
}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public SceneData currentScene;
    // Start is called before the first frame update
    void Awake() {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode){
        switch (scene.buildIndex)
        {
            case 0:
                UIManager.instance.ChangeUI(UI.MAINMENU);
                break;
            default:
                UIManager.instance.ChangeUI(UI.GAMEPLAY);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene(SceneData sceneIndex){
        SceneManager.LoadScene((int)sceneIndex);
        currentScene = sceneIndex;
    }
    public void ChangeScene(int sceneIndex){
        if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = (int)SceneData.MAINMENU;
        }
        SceneManager.LoadScene(sceneIndex);
        currentScene = (SceneData)sceneIndex;
    }
    public void ReLoadScene(){
        SceneManager.LoadScene((int)currentScene);
    }
    public void PauseGame(bool pause = true){
        Time.timeScale = (pause) ? 0 : 1;
    }
}
