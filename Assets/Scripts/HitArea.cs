using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GlobalState.CurrentTable = GetComponent<GameJamTarget>();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (GlobalState.CurrentTable == GetComponent<GameJamTarget>())
            {
                GlobalState.CurrentTable = null;
            };
        }
    }
}
