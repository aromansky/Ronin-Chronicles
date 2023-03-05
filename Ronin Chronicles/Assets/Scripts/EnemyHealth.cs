using System.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HP;
    public KatanaDamage katana;
    private Animator anim;
    private Attack _at;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _at = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Attack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Katana" && _at.hit)
        {
            HP -= katana.Damage;
            _at.DisableCollider();
            if (HP <= 0)
            {
                anim.Play("Death_002");
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Collider>().enabled = false;
            }
                
        }   
    }
}
