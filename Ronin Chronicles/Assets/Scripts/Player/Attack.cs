using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _anim;
    private PlayerCharacteristics _characteristics;
    public bool hit = false;
    private int attack_num = 1;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !hit && _characteristics.HP > 0)
        {
            _anim.Play($"LightAttack_00{attack_num}");
        }

    }

    public void Hit() => hit = !hit;

    public void ResetAttackNum()
    {
        attack_num = 1;
        Invoke("Hit", _characteristics.AttackCd);
    }

    public void IncAttack()
    {
        if (Input.GetMouseButton(0))
            attack_num = (attack_num == 4) ? 1 : ++attack_num;
        else
            attack_num = 1;
    }



}
