using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceManager : MonoBehaviour
{

    public TMPro.TMP_Text text;

    private static SentenceManager instance;

    float timeToDisappear = 0f;
    public float appearanceTime = 4f;

    static string[] sentences = new string[]{
        "Your game sucks!",
        "This is lame!"
    };

    public static void ShowNewWordIfNeeded()
    {
        instance.text.text = sentences[Random.Range(0, sentences.Length)];
        instance.timeToDisappear = instance.appearanceTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        timeToDisappear -= Time.deltaTime;
        if (timeToDisappear < 0)
        {
            text.text = "";
            timeToDisappear = 0;
        }
    }
}
