using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distanceToPlayer;

    private const float distanceError = 0.5f;

    private EnemyCharacteristics _characteristics;
    private EnemyFollower follower;
    private AttackManager _attackManager;

    private GameObject target;
    private float runDistance;
    private float targetDistance;

    void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
        follower = GetComponent<EnemyFollower>();
        _attackManager = GetComponent<AttackManager>();

        target = _characteristics.target;
        runDistance = _characteristics.runDistance;
        targetDistance = _characteristics.targetDistance;
    }

    void Update()
    {
        distanceToPlayer = (gameObject.transform.position - target.transform.position).magnitude;
        MovementLogic();
        AttackLogic();
    }

    private void MovementLogic()
    {
        if (_characteristics.IsDead) return;

        if (distanceToPlayer >= runDistance)
        {
            follower.RunToTarget(target, targetDistance);
        }
        else if ((distanceToPlayer < runDistance) && (distanceToPlayer >= targetDistance))
        {
            follower.WalkToTarget(target, targetDistance);
        }
        else
        {
            follower.StopMoving();
        }
    }


    private void AttackLogic()
    {
        if (distanceToPlayer < targetDistance)
        {
            _attackManager.Attack();
        }
    }
}
