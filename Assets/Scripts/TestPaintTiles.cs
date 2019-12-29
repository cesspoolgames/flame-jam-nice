using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TestPaintTiles : MonoBehaviour
{

    public Tilemap tilemap;

    void Update()
    {
        var index = tilemap.layoutGrid.WorldToCell(transform.position);
        tilemap.SetColor(index, new Color(1, 1, 1, 0));
    }
}