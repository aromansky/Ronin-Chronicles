using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip[] hitSounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HitSound_play()
    {
        audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
    }
}
