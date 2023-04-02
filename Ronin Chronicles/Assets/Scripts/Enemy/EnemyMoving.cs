using Cinemachine.Utility;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public float currentSpeed = 0f;
    private const float distanceError = 0.1f;

    // Movement
    private float moveSpeed;
    private float runSpeed;
    private float acceleration;
    private float turningSpeed;

    // Target following
    private float targetDistance;
    private float visionLength;
    private GameObject target;

    private EnemyCharacteristics _characteristics;
    private CharacterController _characterController;

    private Animator _animator;


    private void Moving(Transform character, Transform target)
    {
        
        Vector3 direction = (target.position - character.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, Time.deltaTime * turningSpeed);

        if (Vector3.Distance(target.position, character.position) <= visionLength)
        {
            if (Vector3.Distance(target.position, character.position) > (targetDistance + visionLength) / 2)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, acceleration);
            }
            else if (Vector3.Distance(target.position, character.position) > targetDistance + distanceError)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration);
            }
            else if (Vector3.Distance(target.position, character.position) < targetDistance - distanceError)
            {
                currentSpeed = -Mathf.Lerp(currentSpeed, moveSpeed, acceleration);
            }
            else
            {
                currentSpeed = 0f;
            }
        }
        else
        {
            currentSpeed = 0f;
        }

        var movement = new Vector3(0, 0, currentSpeed);
        movement = Vector3.ClampMagnitude(movement, currentSpeed);

        movement.y = -9.8f;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);

        _animator.SetFloat("Speed", Math.Abs(currentSpeed));
    }

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
        _animator = GetComponent<Animator>();

        _characteristics = GetComponent<EnemyCharacteristics>();
        _characterController = GetComponent<CharacterController>();

        // Get movement characteristics
        moveSpeed = _characteristics.moveSpeed;
        runSpeed = _characteristics.runSpeed;
        acceleration = _characteristics.acceleration;
        turningSpeed = _characteristics.turningSpeed;

        // Get target following characteristics
        targetDistance = _characteristics.targetDistance;
        visionLength = _characteristics.visionLength;
        target = _characteristics.target;
    }

    void Update()
    {
        if (!_characteristics.IsDead)
                Moving(gameObject.transform, target.transform);

    }
}
