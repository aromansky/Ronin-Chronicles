using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollower : MonoBehaviour
{ 
    private const float distanceError = 0.1f;

    // Movement
    private float moveSpeed;
    private float runSpeed;
    private float acceleration;
    private float turningSpeed;

    private EnemyCharacteristics _characteristics;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    private Vector3 _previousTargetPos;

    private void OnEnable()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _characteristics = GetComponent<EnemyCharacteristics>();
        _previousTargetPos = transform.position;

        // Get movement characteristics
        moveSpeed = _characteristics.moveSpeed;
        runSpeed = _characteristics.runSpeed;
        acceleration = _characteristics.acceleration;
        turningSpeed = _characteristics.turningSpeed;
    }


    /// <summary>
    /// Персонаж начинает идти к позиции объекта target по сетке NavMesh и сохраняет с target дистанцию distance
    /// </summary>
    /// <param name="target">Объект, к которому нужно идти</param>
    /// <param name="distance">Какое расстояние держать до объекта</param>
    public void WalkToTarget(GameObject target, float distance)
    {
        Vector3 targetPos = target.transform.position;
        _navMesh.isStopped = false;

        // Update Characteristics
        _navMesh.speed = moveSpeed;
        _navMesh.acceleration = acceleration;
        _navMesh.angularSpeed = turningSpeed;

        // Check position change
        if (targetPos == _previousTargetPos) return;
        _previousTargetPos = targetPos;

        // Move to Target
        _navMesh.stoppingDistance = distance;
        _navMesh.SetDestination(targetPos);

        _animator.SetFloat("Speed", moveSpeed);
    }


    /// <summary>
    /// Персонаж начинает бежать к позиции объекта target по сетке NavMesh и сохраняет с target дистанцию distance
    /// </summary>
    /// <param name="target">Объект, к которому нужно бежать</param>
    /// <param name="distance">Какое расстояние держать до объекта</param>
    public void RunToTarget(GameObject target, float distance)
    {
        Vector3 targetPos = target.transform.position;
        _navMesh.isStopped = false;

        // Update Characteristics
        _navMesh.speed = runSpeed;
        _navMesh.acceleration = acceleration;
        _navMesh.angularSpeed = turningSpeed;

        // Check position change
        if (targetPos == _previousTargetPos) return;
        _previousTargetPos = targetPos;

        // Move to Target
        _navMesh.stoppingDistance = distance;
        _navMesh.SetDestination(targetPos);

        _animator.SetFloat("Speed", runSpeed);
    }


    public void TurnToTarget(GameObject target)
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, Time.deltaTime * turningSpeed);
    }


    public void StopMoving()
    {
        _navMesh.isStopped = true;
        _animator.SetFloat("Speed", 0);
    }
}
