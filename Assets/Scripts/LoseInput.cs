using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Play winlose background loop
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
