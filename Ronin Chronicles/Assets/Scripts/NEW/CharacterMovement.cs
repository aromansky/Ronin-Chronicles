using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Tooltip("Относительно какого объекта определять движение вперёд/назад/лево/вправо")]
    public Transform obj;

    private const float speedError = 0.01f;
    Vector3 moveDirection;
    Rigidbody characterRigidBody;

    private void Awake()
    {
        characterRigidBody = GetComponent<Rigidbody>();
    }


    /// <summary>
    /// Перемещает персонажа с учётом ускорения в направлении, заданном вектором moveInput
    /// </summary>
    /// <param name="moveInput">Направление движения относительно объекта obj (задаётся через Inspector)</param>
    /// <param name="targetSpeed">С какой скоростью должен двигатсья персонаж</param>
    /// <param name="acceleration">Ускорение и торможение персонажа</param>
    public void HandleMovement(Vector2 moveInput, float targetSpeed, float acceleration)
    {
        moveDirection = obj.forward * moveInput.y;
        moveDirection += obj.right * moveInput.x;
        // Обнулять Y обязательно до нормализации, иначе поворот камеры вверх/вниз будет влиять на скорость движения
        moveDirection.y = 0; // Персонаж не может ходить вверх\вниз
        moveDirection.Normalize();

        // Нормальное ускорение и инерция. Ошибка была в том, что скорость – вектор, а не просто число
        Vector3 targetVelocity = moveDirection * targetSpeed;
        Vector3 velocityDif = targetVelocity - characterRigidBody.velocity;

        characterRigidBody.AddForce(acceleration * velocityDif);
    }


    /// <summary>
    /// Поворачивает персонажа в сторону moveInput относительно объекта obj.
    /// Если персонажа нужно повернуть на месте
    /// </summary>
    /// <param name="moveInput">В каком напралвении смотрит персонаж</param>
    /// /// <param name="rotationSpeed">Скорость поворота персонажа</param>
    public void HandleRotaion(Vector2 moveInput, float rotationSpeed)
    {
        moveDirection = obj.forward * moveInput.y;
        moveDirection += obj.right * moveInput.x;
        moveDirection.Normalize();
        moveDirection.y = 0;    // Персонаж не может смотреть вверх\вниз

        if (moveDirection == Vector3.zero)
        {
            moveDirection = transform.forward;
        }

        // В какую сторону надо повернуть в координатах мира
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // Тут я использовал transform.rotation как первый параметр, поскольку вне зависимости от того,
        // относительно какого объекта задаём вращение, вращать будет объект со скриптом
        Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = rotation;
    }
}
