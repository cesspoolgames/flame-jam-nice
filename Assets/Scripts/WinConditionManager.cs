using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinConditionManager : MonoBehaviour
{
    private static WinConditionManager _instance;
    public static WinConditionManager Instance
    {
        get { return _instance; }
    }
    void Start()
    {
        Timer.OnTimeOut += EndGame;
        Flame.OnBarFilled += GameWon;
    }

    void GameWon()
    {
        SceneManager.LoadScene("Win");
    }

    void EndGame()
    {
        SceneManager.LoadScene("Lose");
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
