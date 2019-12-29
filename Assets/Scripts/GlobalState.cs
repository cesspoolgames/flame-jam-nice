using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour
{

    private static GameJamTable currentTable;
    public static GameJamTable CurrentTable
    {
        set { currentTable = value; } // so we can have more control later on
        get { return currentTable; }
    }
}
