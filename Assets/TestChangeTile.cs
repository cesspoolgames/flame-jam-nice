using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestChangeTile : MonoBehaviour
{
    public Tilemap tilemap;
    // Update is called once per frame
    void Update()
    {
        var thing = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var position = tilemap.layoutGrid.WorldToCell(thing);
        tilemap.SetColor(position, Color.red);
    }
}
