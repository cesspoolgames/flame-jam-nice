using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTheTimer : MonoBehaviour
{
    private static KeepTheTimer instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }
}

