using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private PlayerCharacteristics characteristics;
    private Parry pr;

    public bool hit = false;
    public int attack_num = 1;


    void Start()
    {
        anim = GetComponent<Animator>();
        characteristics = GetComponent<PlayerCharacteristics>();
        pr = GetComponent<Parry>();
    }

    void Update()
    {
        hit = anim.GetBool("Attack_1");
        if (hit != anim.GetBool("Attack_1"))
            Debug.Log($"{hit} - {anim.GetBool("Attack_1")}");   
        if (!PauseMenu.GameIsPaused && !DeathScreen.GameOver && Input.GetMouseButtonDown(0) && !anim.GetBool("Attack_1") && characteristics.HP > 0 && !anim.GetBool("Absorb") && !pr.block && !pr.coolDown)
            anim.Play($"LightAttack_00{attack_num}");
    }

    public void Hit()
    {
        hit = !hit;
        anim.SetBool("Attack_1", hit);    
    }

    void CheckClick() => attack_num = !hit ? 1 : attack_num;

    public void IncAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack_num = (attack_num == 3) ? 1 : ++attack_num;
            Invoke("CheckClick", 1); // Возможно, надо будет подобрать число лучше
        }
        else
            attack_num = 1;
    }
}
