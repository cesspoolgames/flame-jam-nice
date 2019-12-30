using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInput : MonoBehaviour
{
    public AudioSource winOrLoseBg;

    void Start()
    {
        winOrLoseBg.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            GlobalState.RestartLevel();
        }
    }
}
