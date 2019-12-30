using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 1f;
    public AudioSource randomPainAudioSource;
    public AudioClip[] painClips;

    void Start()
    {
        randomPainAudioSource = GameObject.FindWithTag("AudioSourcePain").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayPainSound();
            GlobalState.CurrentTable?.GetHit(damage);
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    public void PlayPainSound()
    {
        randomPainAudioSource.clip = painClips[Random.Range(0, painClips.Length)];
        randomPainAudioSource.PlayOneShot(randomPainAudioSource.clip);
    }
}
