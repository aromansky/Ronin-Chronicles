using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    [Tooltip("Скорость персонажа в данный момент (м/с)")]
    public float currentSpeed = 0f; // Теперь эта переменная отвечает за текущую скорость
    public float gravity; // Эта переменная отвечает за гравитацию

    private float moveSpeed;    // Скорость ходьбы всегда храниться в отдельной переменной, а не перевычисляется
    private float runSpeed;     // Заменил множитель на скорость бега
    
    private PlayerCharacteristics _characteristics;
    private CharacterController _charController;
    private Animator _animator;

    private void Start()
    {
        moveSpeed = GetComponent<PlayerCharacteristics>().moveSpeed;
        runSpeed = GetComponent<PlayerCharacteristics>().runSpeed;
        gravity = GetComponent<PlayerCharacteristics>().gravity;
        _characteristics = GetComponent<PlayerCharacteristics>();
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        gravity *= gravity < 0 ? 1 : -1;
    }

    void Update()
    {
        if (_characteristics.HP > 0 && !_animator.GetBool("Absorb"))
        {
            // Я мог накосячить с векотором movement, так как запутался, где какая скорость должна быть
            // P.S Я починил. Советую перед выгрузкой всё протестить и удалить данный комментарий. Ещё я убрал ненужные {}
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(deltaX * currentSpeed, 0, deltaZ * currentSpeed);
            movement = Vector3.ClampMagnitude(movement, currentSpeed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);

            // TODO 1: Заменить волшебное число 0.1f на какую-нибудь переменную "отклонение скорости" или типа того
            // TODO 2: Инерцию персонажа. То есть от ходьбы к бегу скорость меняется за несколько тактов и наоборот.
            if ((Mathf.Abs(deltaX) < 0.1f) && (Mathf.Abs(deltaZ) < 0.1f))
                currentSpeed = 0;
            else
                if (Input.GetKey(KeyCode.LeftShift))
                    currentSpeed = runSpeed;
                else
                    currentSpeed = moveSpeed;

            // Теперь анимации idle / walk / run сами переключаются в зависимости от параметра Speed
            _animator.SetFloat("Speed", currentSpeed);
        }

    }
}
