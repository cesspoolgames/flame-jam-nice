﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float realTimeSeconds = 10.0f;
    public static float displayTimeHours = 36.0f;
    private float diff = displayTimeHours / realTimeSeconds;
    public delegate void TimerTimeOutAction();
    public static event TimerTimeOutAction OnTimeOut;
    public Flame flame;
    void Update()
    {
        if (realTimeSeconds >= 0)
        {
            TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
            realTimeSeconds -= Time.deltaTime;
            int timeToShow = (int)(realTimeSeconds * diff) + 1;
            mText.text = timeToShow.ToString() + 'h';
            flame.SetFillBar(realTimeSeconds * 0.01f);
        }
        else
        {
            TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
            mText.text = "0h";
            if (OnTimeOut != null)
            {
                OnTimeOut();
            }
        }
    }
}
