using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJamTarget : MonoBehaviour
{
    public float flameCap = 100f; // can't flame over this value
    private float flame = 0f; // decreases over time

    public void GetHit()
    {
        Debug.Log("Hit! " + flame);
        flame += 0.4f;
    }
}
