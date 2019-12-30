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
        GameObject winSound = this.transform.Find("Audio Source Win").gameObject;
        winSound.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Win");
    }

    void EndGame()
    {
        GameObject loseSound = this.transform.Find("Audio Source Lose").gameObject;
        loseSound.GetComponent<AudioSource>().Play();
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
        // DontDestroyOnLoad(this.gameObject);
    }
}
