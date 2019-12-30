using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenStates : MonoBehaviour
{
    public Sprite[] imageOptions;
    private int state = 0;
    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("STATE" + state);
            if (state < 2)
            {
                gameObject.GetComponent<Image>().sprite = imageOptions[state];
            }
            state += 1;
            if (state == 3)
            {
                SceneManager.LoadScene("Level0");
            }
        }
    }
}
