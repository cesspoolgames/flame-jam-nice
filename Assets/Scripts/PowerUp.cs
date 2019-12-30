using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().GivePowerUp();
        Destroy(gameObject);
    }
}
