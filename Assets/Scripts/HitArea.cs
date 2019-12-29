using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    private bool playerOverlap;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerOverlap = true;
            Debug.Log(":) Enter hit area");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerOverlap = false;
            Debug.Log(":( Leave hit area");
        }
    }
}
