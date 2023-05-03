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
        
        // Я не знаю, как это сделать нормально, поэтому будем как яндередев
        _katanaCollider = gameObject.transform.Find("Samurai").Find("LowerBody.001").Find("MiddleBody.001").Find("Chest.001").Find("UpperChest.001").Find("R.Shoulder.001").Find("R.Arm.001").Find("R.Forearm.001").Find("R.Hand.001").Find("Katana").Find("KatanaCollider").gameObject.GetComponent<BoxCollider>();

        _katanaCollider.isTrigger = false;
        isAttacking = false;
        attack_num = 1;
        IsAttackCd = false;
    }


    public void Attack()
    {
        if (IsAttackCd) return;

        if (isAttacking) return;

        _animator.Play($"EnemyLightAttack_00{attack_num}");

        Invoke(nameof(HandleAttackCd), _characteristics.attackCd);

        attack_num = (attack_num % 3) + 1;
    }


    private void HandleAttackCd() => IsAttackCd = false;


    public void ChangeAttackState()
    {
        isAttacking = !isAttacking;
        _katanaCollider.isTrigger = !_katanaCollider.isTrigger;
    }
}
