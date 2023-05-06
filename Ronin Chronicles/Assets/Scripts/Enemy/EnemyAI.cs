using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distanceToPlayer;

    private const float distanceError = 0.5f;

    private EnemyCharacteristics _characteristics;
    private EnemyFollower follower;
    private AttackManager _attackManager;
    private DamageHandler _damageHandler;
    private Animator _animator;

    private GameObject target;
    private float runDistance;
    private float targetDistance;

    void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
        follower = GetComponent<EnemyFollower>();
        _attackManager = GetComponent<AttackManager>();
        _damageHandler = GetComponent<DamageHandler>();
        _animator = GetComponent<Animator>();

        target = _characteristics.target;
        runDistance = _characteristics.runDistance;
        targetDistance = _characteristics.targetDistance;
    }

    void Update()
    {
        distanceToPlayer = (gameObject.transform.position - target.transform.position).magnitude;
        MovementLogic();
        AttackLogic();
        _animator.speed = 1;
    }

    private void MovementLogic()
    {
        if (_characteristics.IsDead) return;

        if (distanceToPlayer > _characteristics.visionLength)
        {
            follower.StopMoving();
            return;
        }

        if (distanceToPlayer >= runDistance)
        {
            _animator.speed = _characteristics.moveSpeed / 7;
            follower.RunToTarget(target, targetDistance);
        }
        else if ((distanceToPlayer < runDistance) && (distanceToPlayer >= targetDistance))
        {
            _animator.speed = _characteristics.moveSpeed / 2.2f;
            follower.WalkToTarget(target, targetDistance);
        }
        else
        {
            follower.StopMoving();
            follower.TurnToTarget(target);
        }
    }


    private void AttackLogic()
    {
        if (_characteristics.IsDead) return;

        if (_damageHandler.damaged) return;

        if (DeathScreen.GameOver) return;

        if (distanceToPlayer < targetDistance)
        {
            _animator.speed = 1;
            _attackManager.Attack();
        }
    }
}
