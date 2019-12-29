using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalState : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject debugText;
    public Flame flameBar;

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
        var sum = 0f;
        foreach (var area in hitAreas)
        {
            var flame = area.GetComponent<GameJamTarget>().Flame;
            text += flame.ToString("0.00") + " | ";
            sum += flame;
        }
        debugText.GetComponent<Text>().text = text + " ==> " + sum.ToString();

        flameBar.SetFillBar(sum / 25);
    }
}
