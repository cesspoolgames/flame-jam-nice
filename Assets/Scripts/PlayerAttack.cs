using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GlobalState.CurrentTable?.GetHit(damage);
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}
