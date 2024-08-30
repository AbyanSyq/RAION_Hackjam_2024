using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIComplete : UIBase
{
    [SerializeField] Button ButtonNext;
    [SerializeField] Button ButtonMainMenu;
    [SerializeField] private TextMeshProUGUI currentRecord;
    [SerializeField] private TextMeshProUGUI record;
    
    private void Awake()
    {
        ButtonNext.onClick.AddListener(NextScene);
        ButtonMainMenu.onClick.AddListener(ToMainMenu);
    }

    void NextScene(){
        GameManager.instance.ChangeScene((int)GameManager.instance.currentScene + 1);
    }

    void ToMainMenu()
    {
        GameManager.instance.ChangeScene(SceneData.MAINMENU);
        Debug.Log("Scene level menu"); 
    }
    public void SetCurrentRecord(float newRecord){

        float record = GameManager.instance.GetLevelRecord();
        if (newRecord < record || record == 0f )
        {
            Debug.Log("COKKKKKKKKK");
            record = newRecord;
            SetNewRecord(newRecord);
        }
        int minutes = Mathf.FloorToInt(newRecord / 60f);
        int seconds = Mathf.FloorToInt(newRecord % 60f);
        int milliseconds = Mathf.FloorToInt((newRecord * 100f) % 100f);
        currentRecord.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        if (record == 0)
        {
            this.record.text = "-";
        }else{
            minutes = Mathf.FloorToInt(record / 60f);
            seconds = Mathf.FloorToInt(record % 60f);
            milliseconds = Mathf.FloorToInt((record * 100f) % 100f);
            this.record.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }

        

    }
    private void SetNewRecord(float newRecord){
        int minutes = Mathf.FloorToInt(newRecord / 60f);
        int seconds = Mathf.FloorToInt(newRecord % 60f);
        int milliseconds = Mathf.FloorToInt((newRecord * 100f) % 100f);
        GameManager.instance.SetLevelRecord(newRecord);
        currentRecord.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
