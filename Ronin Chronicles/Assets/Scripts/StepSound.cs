using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioClip[] stepSounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StepSound_play()
    {
        audioSource.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length)]);
    }
}
