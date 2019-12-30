using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinInput : MonoBehaviour
{
    public AudioSource winOrLoseBg;

    void Start()
    {
        winOrLoseBg.Play();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            GlobalState.LoadNextLevel();
        }
    }
}

