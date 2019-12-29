using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float realTimeSeconds = 300.0f;
    public static float displayTimeHours = 36.0f;
    private float diff = displayTimeHours / realTimeSeconds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
        realTimeSeconds -= Time.deltaTime;
        int timeToShow = (int)(realTimeSeconds * diff);
        mText.text = timeToShow.ToString();
    }
}
