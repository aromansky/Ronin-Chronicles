using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 10f;
    private bool EnemyDied;
    public bool Is_Player;

    private Animator _animator;

    public void ApplyDamage(float damage)
    {
        _animator = GetComponent<Animator>();
         if (EnemyDied)
            return;

        health -= damage;

        //print("Enemy Health = " + health);

        if (health <= 0f)
        {
            //EnemyDied = true;
            _animator.SetBool("Dead", true);
        }
            
    }
}
