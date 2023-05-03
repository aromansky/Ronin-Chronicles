using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerCharacteristics characteristics;


    private void Start()
    {
        characteristics = GetComponent<PlayerCharacteristics>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        GameObject enemy = collider.transform.root.gameObject;

        if (enemy.CompareTag("Enemy"))
        {
            float damage = enemy.GetComponent<EnemyCharacteristics>().damage;

            characteristics.HP -= damage;
        }
    }
}
