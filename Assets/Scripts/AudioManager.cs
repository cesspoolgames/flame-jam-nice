using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float firstLoopPlayMinutes = 2;
    public float secondLoopPlayMinutes = 2;
    public float thirdLoopPlayMinutes = 1;
    private float timePassed;
    private bool soundOneStarted = false;
    private bool soundTwoStarted = false;
    private bool soundThreeStarted = false;

    void Update()
    {
        GameObject sound1 = this.transform.Find("Audio Source Stage One").gameObject;
        GameObject sound2 = this.transform.Find("Audio Source Stage Two").gameObject;
        GameObject sound3 = this.transform.Find("Audio Source Stage Three").gameObject;
        timePassed += Time.deltaTime;
        // Debug.Log(timePassed);
        if (timePassed < (firstLoopPlayMinutes * 60) && !soundOneStarted)
        {
            Debug.Log("a");
            sound1.GetComponent<AudioSource>().Play();
            soundOneStarted = true;
        }
        else if (timePassed >= (firstLoopPlayMinutes * 60) && timePassed < (firstLoopPlayMinutes + secondLoopPlayMinutes) * 60 && !soundTwoStarted)
        {
            Debug.Log("b");
            sound1.GetComponent<AudioSource>().Stop();
            sound2.GetComponent<AudioSource>().Play();
            soundTwoStarted = true;
        }
        else if (!soundThreeStarted && timePassed >= (firstLoopPlayMinutes + secondLoopPlayMinutes) * 60)
        {
            Debug.Log("c");
            sound2.GetComponent<AudioSource>().Stop();
            sound3.GetComponent<AudioSource>().Play();
            soundThreeStarted = true;
        }
    }
}
