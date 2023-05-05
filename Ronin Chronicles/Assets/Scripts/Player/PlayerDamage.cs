using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerCharacteristics characteristics;
    private Parry pr;

    private void Start()
    {
        characteristics = GetComponent<PlayerCharacteristics>();
        pr = GetComponent<Parry>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        GameObject enemy = collider.transform.root.gameObject;

        if (enemy.CompareTag("Enemy"))
        {
            float damage = enemy.GetComponent<EnemyCharacteristics>().damage;

            characteristics.HP -= !pr.block ? damage : 0; // следует потестить
        }
    }
}
