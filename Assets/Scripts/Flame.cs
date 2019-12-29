﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Transform fullFillImage;

    public Transform fillImage;
    private bool barFull = false;
    public delegate void FullBarAction();
    public static event FullBarAction OnBarFilled;
    void Start()
    {
        var newScale = this.fillImage.localScale;
        newScale.x = 0;
        this.fillImage.localScale = newScale;
    }

    public void SetFillBar(float fillAmount)
    {
        if (fillAmount >= 1 && OnBarFilled != null && !barFull)
        {
            barFull = true;
            OnBarFilled();
        }
        fillAmount = Mathf.Clamp01(fillAmount) * 25;
        var newScale = this.fillImage.localScale;
        newScale.x = this.fullFillImage.localScale.y * fillAmount;
        this.fillImage.localScale = newScale;
    }
}
