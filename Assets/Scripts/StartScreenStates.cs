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
            if (state < 2)
            {
                gameObject.GetComponent<Image>().sprite = imageOptions[state];
            }
            else
            {
                SceneManager.LoadScene("Level0");
            }
            state += 1;
        }
    }
}
