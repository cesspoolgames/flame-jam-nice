using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalState : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject debugText;

    private static GameJamTarget currentTable;
    public static GameJamTarget CurrentTable
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

    void Update()
    {
        debugText.GetComponent<Text>().text = "";
        var hitAreas = GameObject.FindGameObjectsWithTag("HitArea");
        var text = "";
        foreach (var area in hitAreas)
        {
            var flame = area.GetComponent<GameJamTarget>().Flame;
            text += flame.ToString("0.00") + " | ";
        }
        debugText.GetComponent<Text>().text = text;
    }
}
