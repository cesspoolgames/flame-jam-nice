using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalState : MonoBehaviour
{
    public GameObject debugText;
    public Flame flameBar;

    private static GameJamTarget currentTable;
    public static GameJamTarget CurrentTable
    {
        set { currentTable = value; } // so we can have more control later on
        get { return currentTable; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
    }

    void Update()
    {
        var hitAreas = GameObject.FindGameObjectsWithTag("HitArea");
        var sum = 0f;
        foreach (var area in hitAreas)
        {
            var flame = area.GetComponent<GameJamTarget>().Flame;
            sum += flame;
        }
        flameBar.SetFillBar(sum / 25); // TODO: per level win condition or %?
    }
}
