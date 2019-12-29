using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapTileChanger : MonoBehaviour
{
    public Tilemap underAttack;
    public Tilemap flamed;

    private static TilemapTileChanger instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void ResetTile(Vector3 tilesetPointer)
    {
        Vector3Int index;
        index = instance.underAttack.layoutGrid.WorldToCell(tilesetPointer);
        instance.underAttack.color = new Color(1, 1, 1, 0);
        index = instance.flamed.layoutGrid.WorldToCell(tilesetPointer);
        instance.flamed.color = new Color(1, 1, 1, 0);
    }

    public static void SetUnderAttack(Vector3 tilesetPointer)
    {
        var index = instance.underAttack.layoutGrid.WorldToCell(tilesetPointer);
        instance.underAttack.SetColor(index, Color.black);
    }
}
