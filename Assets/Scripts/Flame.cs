﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flame : MonoBehaviour
{
    public Transform fullFillImage;

    public Transform fillImage;
    public int fillRate = 3;
    private bool barFull = false;
    public delegate void FullBarAction();
    public static event FullBarAction OnBarFilled;
    void Start()
    {
        SceneManager.sceneLoaded += FindNewFillImage;
        ResetEverything();
    }

    void ResetEverything()
    {
        barFull = false;
        fillImage = GameObject.Find("FlameMask").transform;
        var newScale = this.fillImage.localScale;
        newScale.x = 0;
        this.fillImage.localScale = newScale;
    }

    void FindNewFillImage(Scene scene, LoadSceneMode loadMode)
    {
        ResetEverything();
    }

    public void SetFillBar(float fillAmount)
    {
        if (fillAmount >= 1 && !barFull)
        {
            Debug.Log("TRUE");
            barFull = true;
            if (OnBarFilled != null)
            {
                Debug.Log("NICE");
                OnBarFilled();
            }
        }
        if (fillImage)
        {
            fillAmount = Mathf.Clamp01(fillAmount) * fillRate;
            var newScale = this.fillImage.localScale;
            newScale.x = this.fullFillImage.localScale.y * fillAmount;
            this.fillImage.localScale = newScale;
        }
    }
}
