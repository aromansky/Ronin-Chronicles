using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private float hp;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hp = GetComponent<EnemyCharacteristics>().HP;
        if (hp <= 0)
        {
            anim.Play("Death");
            gameObject.tag = "Untagged";
            GetComponent<EnemyCharacteristics>().IsDead = true;
        }
            
    }
}
