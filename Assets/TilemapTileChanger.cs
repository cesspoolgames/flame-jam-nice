using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapTileChanger : MonoBehaviour
{
    public Tilemap underAttack;
    public Tilemap flamed;

    private static TilemapTileChanger instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void ResetTile(Vector3 tilePosition)
    {
        Vector3Int index;
        index = instance.underAttack.WorldToCell(tilePosition);
        instance.underAttack.SetTileFlags(index, TileFlags.None);
        instance.underAttack.SetColor(index, new Color(1, 1, 1, 0));
        index = instance.flamed.WorldToCell(tilePosition);
        instance.flamed.SetTileFlags(index, TileFlags.None);
        instance.flamed.SetColor(index, new Color(1, 1, 1, 0));
    }

    public static void SetUnderAttack(Vector3 tilePosition)
    {
        var index = instance.underAttack.WorldToCell(tilePosition);
        instance.underAttack.SetColor(index, new Color(1, 1, 1, 1));
    }
}
