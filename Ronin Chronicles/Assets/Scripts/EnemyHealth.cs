using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HP;
    public KatanaDamage katana;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Katana_1")
        {
            HP -= katana.Damage;
            if (HP <= 0)
                anim.Play("Death_002");
        }
            
    }

}
