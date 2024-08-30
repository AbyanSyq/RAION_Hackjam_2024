using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGamePlay : UIBase
{
    [SerializeField] Button ButtonPause;
    [SerializeField] private TextMeshProUGUI stopwatchText;
    [SerializeField] private TextMeshProUGUI timerText;
    public float stopwatch = 0f;
    public float timer;
    public bool isRunning = false;
    private bool isTimer;
    private bool isOver = false;

    void Start()
    {
        ButtonPause.onClick.AddListener(Pause);
        isTimer = LevelManager.instance.isTimer;
        if (isTimer)
        { 
            timer = LevelManager.instance.timerAmount;
            timerText.gameObject.SetActive(true);
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            Debug.Log("Setted");
        }
        UpdateStopwatchText(0f);
    }

    void Update()
    {
        if (isRunning)
        {
            stopwatch += Time.deltaTime;
            UpdateStopwatchText(stopwatch);
            if (isTimer)
            { 
                timer -= Time.deltaTime;
                UpdateTimerText(timer);
            }
        }
    }

    private void UpdateStopwatchText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        stopwatchText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        if (time < 0 && !isOver)
        {
            isOver = true;
            StartCoroutine(LevelManager.instance.MachineDestroy());
            timerText.gameObject.SetActive(false);

        }
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public float StopStopwatch()
    {
        isRunning = false;
        return stopwatch;
    }

    public void ResetStopwatch()
    {
        stopwatch = 0f;
        UpdateStopwatchText(stopwatch);
    }
    public void Pause(){
        UIManager.instance.ChangeUI(UI.PAUSE);
    }
}

