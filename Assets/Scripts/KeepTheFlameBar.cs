using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTheFlameBar : MonoBehaviour
{
    private static KeepTheFlameBar instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
    }
}
