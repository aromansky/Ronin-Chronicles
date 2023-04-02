using Cinemachine.Utility;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    private float speed;
    private float turningSpeed;
    private float targetDistance;
    private float visionLength;
    private GameObject target;

    private EnemyCharacteristics _characteristics;
    const float eps = 0.1f;

    private Animator _animator;


    void Moving(Transform character, Transform target)
    {
        
        Vector3 direction = (target.position - character.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, Time.deltaTime * turningSpeed);

        if (Vector3.Distance(target.position, character.position) <= visionLength && Vector3.Distance(target.position, character.position) > targetDistance)
        {
            transform.position = Vector3.MoveTowards(character.position, target.position, Time.deltaTime * speed);
            _animator.Play("Walk");
        }

        var dist = Vector3.Distance(target.position, character.position);
        if (dist < targetDistance - eps || dist > targetDistance + eps)
        {

            float angle = target.eulerAngles.y * (float)Math.PI / 180;
            Vector3 backStep = new Vector3(target.position.x + targetDistance * (float)Math.Sin(angle), -10f, target.position.z + targetDistance * (float)Math.Cos(angle));

            transform.position = Vector3.MoveTowards(character.position, backStep, Time.deltaTime * speed);

            if (backStep.magnitude < eps)
                _animator.Play("Idle");
            else
                _animator.Play("Walk");
        }
        

    }

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
        _animator = GetComponent<Animator>();


        speed = GetComponent<EnemyCharacteristics>().speed;
        turningSpeed = GetComponent<EnemyCharacteristics>().turningSpeed;
        targetDistance = GetComponent<EnemyCharacteristics>().targetDistance;
        visionLength = GetComponent<EnemyCharacteristics>().visionLength;
        target = GetComponent<EnemyCharacteristics>().target;
        _characteristics = GetComponent<EnemyCharacteristics>();
    }

    void Update()
    {
        if(!_characteristics.IsDead)
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= visionLength)
            Moving(gameObject.transform, target.transform);
        else
            _animator.Play("Idle");
    }
}
