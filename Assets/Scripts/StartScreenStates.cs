﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenStates : MonoBehaviour
{
    public Sprite[] imageOptions;
    private int state = 0;
    void Start()
    {

    }

    void Update()
    {
        if (state < 2 && Input.anyKeyDown)
        {
            gameObject.GetComponent<Image>().sprite = imageOptions[state];
            state += 1;
        }
        else if (state == 2)
        {
            SceneManager.LoadScene("Level0");
        }
    }
}