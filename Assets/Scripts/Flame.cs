using System.Collections;
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
        fillImage = GameObject.Find("FlameMask").transform;
        Debug.Log("New fill image: " + fillImage);
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
        if (fillAmount >= 1 && OnBarFilled != null && !barFull)
        {
            barFull = true;
            OnBarFilled();
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
