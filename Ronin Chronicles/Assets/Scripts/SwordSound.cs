using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound : MonoBehaviour
{
    public AudioClip[] swordSounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SwordSound_play()
    {
        audioSource.PlayOneShot(swordSounds[Random.Range(0, swordSounds.Length)]);
    }
}