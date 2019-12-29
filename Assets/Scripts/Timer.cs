using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30.0f;  
    public float scrollBar = 30.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = scrollBar;
        timeLeft -= Time.deltaTime;
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = timeLeft.ToString();
    }
}
