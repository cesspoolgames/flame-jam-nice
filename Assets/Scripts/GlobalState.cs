﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public float playerSpeed = 3;
    public float defaultLevelSeconds = 60;
    public float winFlamingTargetPercent = 80;

    public Flame flameBar;

    private static GameJamTarget currentTable;

    private static int level = 0;

    static public GlobalState instance;

    public static GameJamTarget CurrentTable
    {
        set { currentTable = value; } // so we can have more control later on
        get { return currentTable; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    static public void LoadNextLevel()
    {
        level++;
        SceneManager.LoadScene("Level" + level);
    }

    static public void RestartLevel()
    {
        SceneManager.LoadScene("Level" + level);
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
        var totalNeeded = hitAreas.Length * 10 * winFlamingTargetPercent / 100; // 10 magic number = flaming cap
        flameBar.SetFillBar(sum / totalNeeded); // TODO: per level win condition or %?
    }
}
