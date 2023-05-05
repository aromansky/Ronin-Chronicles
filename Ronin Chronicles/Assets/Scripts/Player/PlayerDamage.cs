using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public AudioClip[] hitSounds;

    private PlayerCharacteristics characteristics;
    private Parry pr;
    private AudioSource audioSource;

    private void Start()
    {
        characteristics = GetComponent<PlayerCharacteristics>();
        pr = GetComponent<Parry>();
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        GameObject enemy = collider.transform.root.gameObject;

        if (!enemy.CompareTag("Enemy")) return;

        if (pr.block) return;


        float damage = enemy.GetComponent<EnemyCharacteristics>().damage;

        characteristics.HP -= damage;
        audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
    }
}
