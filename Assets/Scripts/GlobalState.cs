using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalState : MonoBehaviour
{
    public GameObject gameOverText;

    private static GameJamTable currentTable;
    public static GameJamTable CurrentTable
    {
        set { currentTable = value; } // so we can have more control later on
        get { return currentTable; }
    }

    void Start()
    {
        Timer.OnTimeOut += OnTimeOut;
    }

    void Destroy()
    {
        Timer.OnTimeOut -= OnTimeOut;
    }

    void OnTimeOut()
    {
        gameOverText.SetActive(true);
    }
}
