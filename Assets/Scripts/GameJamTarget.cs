﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJamTarget : MonoBehaviour
{
    const float flameCap = 10f; // can't flame over this value
    public AudioSource badFlameSound;
    public AudioSource goodFlameSound;
    public AudioSource totallyFlamedSound;
    private float flame = 0f; // decreases over time
    private Transform tilePointer;
    private bool flamed = false; // when flamed is reached, keeps the flamed state until cooled down

    public float Flame
    {
        get { return flame; }
    }

    void Start()
    {
        tilePointer = transform.Find("TilePointer");
        TilemapTileChanger.ResetTile(tilePointer.position);
        badFlameSound = GameObject.FindWithTag("AudioSourceFlamedBad").GetComponent<AudioSource>();
        goodFlameSound = GameObject.FindWithTag("AudioSourceFlamedGood").GetComponent<AudioSource>();
        totallyFlamedSound = GameObject.FindWithTag("AudioSourceTotallyFlamed").GetComponent<AudioSource>();
    }

    public void GetHit(float howMuch)
    {
        SentenceManager.ShowNewWordIfNeeded();
        TilemapTileChanger.SetUnderAttack(tilePointer.position);
        flame += howMuch;
        if (flame > flameCap)
        {
            flame = flameCap;
            TilemapTileChanger.SetFlamed(tilePointer.position);
            flamed = true;
            totallyFlamedSound.PlayOneShot(totallyFlamedSound.clip);
        }
        if (flamed)
        {
            badFlameSound.PlayOneShot(badFlameSound.clip);
        }
        else
        {
            goodFlameSound.PlayOneShot(goodFlameSound.clip);
        }
    }

    void Update()
    {
        if (flame > 0)
        {
            flame -= GlobalState.instance.healPerSecond * Time.deltaTime;
        }

        if (flamed && flame / flameCap < 0.8f) // TODO: maybe put in a global UI changeable value
        {
            flamed = false;
            TilemapTileChanger.ResetTile(tilePointer.position);
        }

        if (flame < 0)
        {
            flame = 0;
        }
    }
}
