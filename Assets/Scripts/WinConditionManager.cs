using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionManager : MonoBehaviour
{
    public AudioManager manager;
    public int lastLevel = 2;
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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        manager.StopSceneMusic();
        if ("Level" + lastLevel.ToString() == sceneName)
        {
            GameObject winFinalSound = this.transform.Find("Audio Source Final Win").gameObject;
            winFinalSound.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("FinalWin");
        }
        else
        {
            GameObject winSound = this.transform.Find("Audio Source Win").gameObject;
            winSound.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("Win");
        }

    }

    void EndGame()
    {
        manager.StopSceneMusic();
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
