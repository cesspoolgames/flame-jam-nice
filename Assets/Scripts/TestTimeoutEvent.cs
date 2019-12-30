using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestTimeoutEvent : MonoBehaviour
{
    private static TestTimeoutEvent _instance;
    public static TestTimeoutEvent Instance
    {
        get { return _instance; }
    }
    void Start()
    {
        Timer.OnTimeOut += EndGame;
        Flame.OnBarFilled += GameWon;
    }

    void Destroy()
    {
        Timer.OnTimeOut -= EndGame;
        Flame.OnBarFilled -= GameWon;
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
