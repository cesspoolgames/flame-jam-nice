﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            GlobalState.LoadNextLevel();
        }
    }
}

