using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float realTimeSeconds = 10.0f;
    public float displayTimeHours = 36.0f;
    private float diff;
    public delegate void TimerTimeOutAction();
    public static event TimerTimeOutAction OnTimeOut;

    public void RestartTime()
    {
        realTimeSeconds = GlobalState.instance.defaultLevelSeconds;
        diff = displayTimeHours / realTimeSeconds;
        timeEnded = false;
    }

    bool timeEnded = false;

    void Start()
    {
        RestartTime();
        GlobalState.OnLevelStart += RestartTime;
    }

    void Update()
    {
        if (realTimeSeconds >= 0)
        {
            TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
            if (GlobalState.instance.timerRunning)
            {
                realTimeSeconds -= Time.deltaTime;
            }
            int timeToShow = (int)(realTimeSeconds * diff) + 1;
            mText.text = timeToShow.ToString() + ":00";
        }
        else
        {
            TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
            mText.text = "0:00";
            if (OnTimeOut != null && !timeEnded)
            {
                timeEnded = true;
                OnTimeOut();
            }
        }
    }
}
