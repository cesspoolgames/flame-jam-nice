using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJamTarget : MonoBehaviour
{
    public float flameCap = 10f; // can't flame over this value
    private float flame = 0f; // decreases over time
    private float healPerSecond = 0.5f;

    private Transform tilePointer;

    public float Flame
    {
        get { return flame; }
    }

    void Start()
    {
        tilePointer = transform.Find("TilePointer");
    }

    public void GetHit(float howMuch)
    {
        TilemapTileChanger.SetUnderAttack(tilePointer.position);
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
