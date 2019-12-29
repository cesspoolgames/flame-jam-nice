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
            GlobalState.CurrentTable = GetComponent<GameJamTarget>();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerOverlap = false;
            if (GlobalState.CurrentTable == GetComponent<GameJamTarget>())
            {
                GlobalState.CurrentTable = null;
            };
        }
    }
}
