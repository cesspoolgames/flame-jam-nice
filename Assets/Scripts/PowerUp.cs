using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioSource powerupAudioSource;

    void OnTriggerEnter2D(Collider2D collider)
    {
        powerupAudioSource = GameObject.FindWithTag("AudioSourcePowerup").GetComponent<AudioSource>();
        powerupAudioSource.PlayOneShot(powerupAudioSource.clip);
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().GivePowerUp();
        Destroy(gameObject);
    }
}
