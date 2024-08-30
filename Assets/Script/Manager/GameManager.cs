using System;
using UnityEngine;
using UnityEngine.SceneManagement;
[Serializable]
public struct LevelData{
    public int levelIndex;
    public bool isComplete;
    public float record;
}
public enum SceneData{//NANTI SEUAIIN SAMA DI BUILD
    MAINMENU,
    LEVEL01,
    LEVEL02,
    Level03,
}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public int coin;
    public LevelData[] levelData;
    public SceneData currentScene;
    public int levelIndex;
    // Start is called before the first frame update
    void Awake() {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    private void Start() {
        MusicManager.Instance.PlayMusic("BGM");
        LoadLevel();
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode){
        switch (scene.buildIndex)
        {
            case 0:
                UIManager.instance.ChangeUI(UI.MAINMENU);
                MusicManager.Instance.PlayMusic("BGM");
                break;
            default:
                UIManager.instance.ChangeUI(UI.GAMEPLAY);
                break;
        }
    }
    public void ChangeScene(SceneData sceneIndex){
        SceneManager.LoadScene((int)sceneIndex);
        levelIndex = (int)sceneIndex -1;
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
    public float GetLevelRecord(){
        return levelData[levelIndex].record;
    }
    public void SetLevelRecord(float newRecord){
        levelData[levelIndex].record = newRecord;
        SaveLevel();
    }
    public void SetLevelComplete(bool isComplete = true){
        levelData[levelIndex].isComplete = isComplete;
    }
    public bool GetLevelComplete(int levelIndex){
        return levelData[levelIndex].isComplete;
    }
    public void SaveLevel(){
        foreach (LevelData levelData in levelData)
        {
            SaveLoadSystem.SaveLevelData(levelData);
        }
    }
    public void LoadLevel(){
        for (int i = 0; i < levelData.Length; i++)
        {
            levelData[i] = SaveLoadSystem.LoadLevelData(i);
        }
    }
    public void SavePlayerData(){
        SaveLoadSystem.SaveCoins(coin);
    }
    public void LoadCoins(){
        coin = SaveLoadSystem.LoadCoins();
    }
}
