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
        // Бога больше нет
        GameObject enemy = collider.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.gameObject;

        if (!enemy.CompareTag("Enemy")) return;

        if (pr.block) return;


        float damage = enemy.GetComponent<EnemyCharacteristics>().damage;

        characteristics.HP -= damage;

        if (characteristics.HP < 0) characteristics.HP = 0;

        audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
    }
}
