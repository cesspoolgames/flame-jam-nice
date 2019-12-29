﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Transform fullFillImage;

    public Transform fillImage;
    void Start()
    {
        var newScale = this.fillImage.localScale;
        newScale.x = 0;
        this.fillImage.localScale = newScale;
    }

    public void SetFillBar(float fillAmount)
    {
        fillAmount = Mathf.Clamp01(fillAmount) * 25;
        var newScale = this.fillImage.localScale;
        newScale.x = this.fullFillImage.localScale.y * fillAmount;
        this.fillImage.localScale = newScale;
    }
}
