using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInput : MonoBehaviour
{
    public AudioSource winOrLoseBg;

    void Start()
    {
        if (winOrLoseBg != null)
        {
            winOrLoseBg.Play();
        }
        else
        {
            winOrLoseBg = GameObject.FindWithTag("AudioSourceLoseOrWinBgMusic").GetComponent<AudioSource>();
            winOrLoseBg.Play();
        }
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
