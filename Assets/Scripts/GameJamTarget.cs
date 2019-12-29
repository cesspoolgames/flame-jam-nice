using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJamTarget : MonoBehaviour
{
    public float flameCap = 10f; // can't flame over this value
    private float flame = 0f; // decreases over time
    private float healPerSecond = 0.5f;

    public float Flame
    {
        get { return flame; }
    }

    public void GetHit(float howMuch)
    {
        flame += howMuch;
        if (flame > flameCap)
        {
            flame = flameCap;
        }
    }

    void Update()
    {
        if (flame > 0)
        {
            flame -= healPerSecond * Time.deltaTime;
        }

        if (flame < 0)
        {
            flame = 0;
        }
    }
}
