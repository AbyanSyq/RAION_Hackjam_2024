using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGamePlay : UIBase
{
    [SerializeField] Button ButtonPause;
    [SerializeField] private TextMeshProUGUI stopwatchText;
    public float stopwatch = 0f;
    public bool isRunning = false;

    void Start()
    {
        ButtonPause.onClick.AddListener(Pause);
        UpdateStopwatchText(0f);
    }

    void Update()
    {
        if (isRunning)
        {
            stopwatch += Time.deltaTime;
            UpdateStopwatchText(stopwatch);
        }
    }

    private void UpdateStopwatchText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        stopwatchText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StopStopwatch()
    {
        isRunning = false;
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

