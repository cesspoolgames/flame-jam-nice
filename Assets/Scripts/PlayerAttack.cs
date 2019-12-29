using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GlobalState.CurrentTable)
            {
                GlobalState.CurrentTable.GetHit();
            }
        }
    }
}
