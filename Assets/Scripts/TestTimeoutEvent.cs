using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeoutEvent : MonoBehaviour
{
    void Start()
    {
        Timer.OnTimeOut += Log;
    }

    void Log() {
        Debug.Log("Yoske placeholder");
    }
}
