using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackManager : MonoBehaviour
{
    public bool isAttacking;
    public int attack_num;
    public bool IsAttackCd;

    private Animator _animator;
    private EnemyCharacteristics _characteristics;
    private BoxCollider _katanaCollider;


    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _characteristics = GetComponent<EnemyCharacteristics>();
        
        // я не знаю, как это сделать нормально, поэтому будем как €ндередев
        _katanaCollider = gameObject.transform.Find("Samurai").Find("LowerBody.001").Find("MiddleBody.001").Find("Chest.001").Find("UpperChest.001").Find("R.Shoulder.001").Find("R.Arm.001").Find("R.Forearm.001").Find("R.Hand.001").Find("Katana").Find("KatanaCollider").gameObject.GetComponent<BoxCollider>();

        _katanaCollider.isTrigger = false;
        isAttacking = false;
        attack_num = 1;
        IsAttackCd = false;
    }


    /// <summary>
    /// „тобы не писать тот же ужас по нахождению _katanaCollider в скрипте смерти,
    /// решил провер€ть смерть здесь. »наче игрок упираетс€ в катану трупа.
    /// </summary>
    private void Update()
    {
        if (_characteristics.IsDead)
        {
            _katanaCollider.enabled = false;
        }
    }


    public void Attack()
    {
        if (IsAttackCd) return;

        if (isAttacking) return;

        _animator.Play($"EnemyLightAttack_00{attack_num}");
        IsAttackCd = true;

        Invoke(nameof(HandleAttackCd), _characteristics.attackCd);
        attack_num = (attack_num % 3) + 1;
    }


    private void HandleAttackCd() => IsAttackCd = false;


    public void ChangeAttackState()
    {
        isAttacking = !isAttacking;
        _katanaCollider.isTrigger = !_katanaCollider.isTrigger;
        _animator.SetBool("IsAttacking", !_animator.GetBool("IsAttacking"));
    }
}
