using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTimeoutEvent : MonoBehaviour
{
    private bool didWin = false;
    private bool didLose = false;
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

    void GameWon()
    {
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "You Win! Press Any Key to Continue";
        didWin = true;
    }

    void EndGame()
    {
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "Press Any Key to Try Again";
        didLose = true;
    }

    void Update()
    {
        if (Input.anyKeyDown && didLose)
        {
            Debug.Log("lose");
            didLose = false;
            Application.LoadLevel(1);
        }
        else if (Input.anyKeyDown && didWin)
        {
            Debug.Log("win");
            didWin = false;
            Application.LoadLevel(2);
        }
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
