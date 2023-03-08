using System;
using Unity.VisualScripting;
using UnityEngine;

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
        }
        if (Vector3.Distance(target.position, character.position) < targetDistance - eps)
        {
            
            float angle = target.eulerAngles.y * (float) Math.PI/180;
            Vector3 backStep = new Vector3(target.position.x + targetDistance * (float)Math.Sin(angle), 0f, target.position.z + targetDistance * (float)Math.Cos(angle));
            transform.position = Vector3.MoveTowards(character.position, backStep, Time.deltaTime * speed);
            
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
        if(_characteristics.HP > 0)
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= visionLength)
            {
                Moving(gameObject.transform, target.transform);
                _animator.Play("Walk");
            }
            else
                _animator.Play("Idle");
    }
}
