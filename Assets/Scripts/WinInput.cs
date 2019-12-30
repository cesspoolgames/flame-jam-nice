using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinInput : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        // Play winlose background loop
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            GlobalState.LoadNextLevel();
        }
    }
}

