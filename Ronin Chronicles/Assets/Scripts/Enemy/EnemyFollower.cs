using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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

    private void OnEnable()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _characteristics = GetComponent<EnemyCharacteristics>();

        // Get movement characteristics
        moveSpeed = _characteristics.moveSpeed;
        runSpeed = _characteristics.runSpeed;
        acceleration = _characteristics.acceleration;
        turningSpeed = _characteristics.turningSpeed;
    }


    /// <summary>
    /// �������� �������� ���� � ������� ������� target �� ����� NavMesh � ��������� � target ��������� distance
    /// </summary>
    /// <param name="target">������, � �������� ����� ����</param>
    /// <param name="distance">����� ���������� ������� �� �������</param>
    public void WalkToTarget(GameObject target, float distance)
    {
        _navMesh.isStopped = false;
        Vector3 targetPos = target.transform.position;

        // Update Characteristics
        _navMesh.speed = moveSpeed;
        _navMesh.acceleration = acceleration;
        _navMesh.angularSpeed = turningSpeed;

        // Move to Target
        _navMesh.stoppingDistance = distance;
        _navMesh.SetDestination(targetPos);

        _animator.SetFloat("Speed", moveSpeed);
    }


    /// <summary>
    /// �������� �������� ������ � ������� ������� target �� ����� NavMesh � ��������� � target ��������� distance
    /// </summary>
    /// <param name="target">������, � �������� ����� ������</param>
    /// <param name="distance">����� ���������� ������� �� �������</param>
    public void RunToTarget(GameObject target, float distance)
    {
        _navMesh.isStopped = false;
        Vector3 targetPos = target.transform.position;

        // Update Characteristics
        _navMesh.speed = runSpeed;
        _navMesh.acceleration = acceleration;
        _navMesh.angularSpeed = turningSpeed;

        // Move to Target
        _navMesh.stoppingDistance = distance;
        _navMesh.SetDestination(targetPos);

        _animator.SetFloat("Speed", runSpeed);
    }


    public void StopMoving()
    {
        _navMesh.isStopped = true;
        _animator.SetFloat("Speed", 0);
    }
}
