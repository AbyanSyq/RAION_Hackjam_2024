using System;
using UnityEngine;

public static class SaveLoadSystem
{
    private const string CoinsKey = "Coins";
    private const string LevelDataKey = "LevelData_"; // We will append the levelIndex to this key

    public static void SaveLevelData(LevelData levelData)
    {
        string key = LevelDataKey + levelData.levelIndex;
        PlayerPrefs.SetInt(key + "_isComplete", levelData.isComplete ? 1 : 0);
        PlayerPrefs.SetFloat(key + "_record", levelData.record);
        PlayerPrefs.Save();
    }

    public static LevelData LoadLevelData(int levelIndex)
    {
        LevelData levelData = new LevelData();
        string key = LevelDataKey + levelIndex;

        levelData.levelIndex = levelIndex;
        levelData.isComplete = PlayerPrefs.GetInt(key + "_isComplete", 0) == 1;
        levelData.record = PlayerPrefs.GetFloat(key + "_record", 0f);

        return levelData;
    }

    public static void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt(CoinsKey, coins);
    }

    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(CoinsKey, 0);
    }

    public static void ResetData(int totalLevels)
    {
        Debug.Log("ini kepencet anjggggg");
        // Reset coins
        PlayerPrefs.SetInt(CoinsKey, 0);

        // Reset all level data
        for (int i = 0; i < totalLevels; i++)
        {
            string key = LevelDataKey + i;
            PlayerPrefs.SetInt(key + "_isComplete", 0);
            PlayerPrefs.SetFloat(key + "_record", 0f);
        }

        PlayerPrefs.Save();
        GameManager.instance.LoadLevel();
    }
}
