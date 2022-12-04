using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float speed; // скорость пермещения персонажа 
    public float turningSpeed; // скорость поворота персонажа 
    public float targetDistance; // расстояние, на котором персонаж будет держатся от игрока
    public float visionLength; // расстояние, на которое может смотреть
    public GameObject target;
    const float eps = 0.1f;

    private Animator _animator;


    void Moving(Transform character, Transform target) // перемещение персонажа
    {
        // поворот в сторону цели
        Vector3 direction = (target.position - character.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, Time.deltaTime * turningSpeed);

        if (Vector3.Distance(target.position, character.position) <= visionLength && Vector3.Distance(target.position, character.position) > targetDistance) // Проверка расстояния до игрока 
        {
            transform.position = Vector3.MoveTowards(character.position, target.position, Time.deltaTime * speed);
        }
        if (Vector3.Distance(target.position, character.position) < targetDistance - eps)
        {
            // держится всегда перед "лицом" игрока, находясь на заданной дистанции
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= visionLength)
        {
            Moving(gameObject.transform, target.transform);
            _animator.SetBool("Move", true);
        }
        else
            _animator.SetBool("Move", false);
    }


}
