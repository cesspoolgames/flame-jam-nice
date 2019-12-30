using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public float playerSpeed = 3;
    public float powerUpTimeSeconds = 2;
    public float powerUpSpeedFactor = 2;
    public float defaultLevelSeconds = 60;
    public float winFlamingTargetPercent = 80;
    public float healPerSecond = 0.5f;

    public Flame flameBar;
    public AudioManager manager;
    private static GameJamTarget currentTable;

    private static int level = 0;
    public bool timerRunning = true;

    static public GlobalState instance;

    public delegate void OnLevelStartAction();
    public static event OnLevelStartAction OnLevelStart;

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
        Timer.OnTimeOut += StopTimer;
        Flame.OnBarFilled += StopTimer;
    }

    void StopTimer()
    {
        timerRunning = false;
    }

    static public void LoadNextLevel()
    {
        level++;
        Debug.Log("LEVEL!" + level);
        SceneManager.LoadScene("Level" + level);
        instance.timerRunning = true;
        if (OnLevelStart != null)
        {
            OnLevelStart();
        }
    }

    static public void RestartLevel()
    {
        SceneManager.LoadScene("Level" + level);
        instance.timerRunning = true;
        if (OnLevelStart != null)
        {
            OnLevelStart();
        }
    }

    void Update()
    {
        var hitAreas = GameObject.FindGameObjectsWithTag("HitArea");
        var sum = 0f;
        foreach (var area in hitAreas)
        {
            var flameAmountOfArea = area.GetComponent<GameJamTarget>().Flame;
            sum += flameAmountOfArea;
        }
        if (hitAreas.Length > 0)
        {
            var totalNeeded = hitAreas.Length * 10 * winFlamingTargetPercent / 100; // 10 magic number = flaming cap
            flameBar.SetFillBar(sum / totalNeeded); // TODO: per level win condition or %?
        }
    }
}
