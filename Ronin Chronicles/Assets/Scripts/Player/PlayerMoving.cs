using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    [Tooltip("Current character movement speed (m/s)")]
    public float currentSpeed = 0f;
    public float gravity = -9.8f;

    private float moveSpeed;
    private float runSpeed;
    private float acceleration;
    private const float speedError = 0.05f; // ����������� ��������, ��� eps, �� ������ ��� ��������.

    private PlayerCharacteristics _characteristics;
    private CharacterController _charController;
    private Animator _animator;
    private Parry _pr;

    private void Start()
    {
        moveSpeed = GetComponent<PlayerCharacteristics>().moveSpeed;
        runSpeed = GetComponent<PlayerCharacteristics>().runSpeed;
        acceleration = GetComponent<PlayerCharacteristics>().acceleration;
        gravity = GetComponent<PlayerCharacteristics>().gravity;
        _characteristics = GetComponent<PlayerCharacteristics>();
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _pr = GetComponent<Parry>();

        gravity *= gravity < 0 ? 1 : -1;
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused && !DeathScreen.GameOver && _characteristics.HP > 0 && !_animator.GetBool("Absorb") && !_pr.block)
        {
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(deltaX * currentSpeed, 0, deltaZ * currentSpeed);
            movement = Vector3.ClampMagnitude(movement, currentSpeed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);


            // Основной расчёт скорости
            if ((Mathf.Abs(deltaX) < speedError) && (Mathf.Abs(deltaZ) < speedError))
            {
                currentSpeed = Mathf.Lerp(0, currentSpeed, 1 - acceleration * Time.deltaTime);
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) && (deltaZ >= 0f))
                {
                    currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, acceleration * Time.deltaTime);
                }
                else if (currentSpeed > moveSpeed)
                {
                    currentSpeed = Mathf.Lerp(moveSpeed, currentSpeed, 1 - acceleration * Time.deltaTime);
                }
                else
                {
                    currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
                }
            }


            // "Подгоняю" скорость до ближайшей заданной
            if ((currentSpeed < runSpeed) && (currentSpeed >= runSpeed - speedError))
            {
                currentSpeed = runSpeed;
            }
            else if ((currentSpeed >= moveSpeed - speedError) && (currentSpeed <= moveSpeed + speedError))
            {
                currentSpeed = moveSpeed;
            }
            else if ((currentSpeed > 0) && (currentSpeed <= speedError))
            {
                currentSpeed = 0f;
            }

            _animator.SetFloat("Speed", currentSpeed);
        }
    }
}
