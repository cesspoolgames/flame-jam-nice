using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public GameObject debugText;
    private Flame flameBar;

    private static GameJamTarget currentTable;
    public static GameJamTarget CurrentTable
    {
        set { currentTable = value; } // so we can have more control later on
        get { return currentTable; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SearchForFlameBar;
    }

    void SearchForFlameBar(Scene scene, LoadSceneMode mode)
    {
        flameBar = GameObject.FindObjectOfType<Flame>();
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
        if (flameBar)
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
}
