using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private PlayerCharacteristics characteristics;
    public bool hit = false;
    private int attack_num = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused && Input.GetMouseButtonDown(0) && !hit && characteristics.HP > 0 && !anim.GetBool("Absorb"))
            anim.Play($"LightAttack_00{attack_num}");

    }

    public void Hit() => hit = !hit;

    public void ResetAttackNum()
    {
        attack_num = 1;
        Invoke("Hit", characteristics.AttackCd);
    }

    public void IncAttack()
    {
        if (Input.GetMouseButton(0))
            attack_num = (attack_num == 4) ? 1 : ++attack_num;
        else
            attack_num = 1;
    }
}
