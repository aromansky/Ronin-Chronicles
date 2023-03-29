using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [Tooltip("—корость персонажа в данный момент (м/с)")]
    public float currentSpeed = 0f; // “еперь эта переменна€ отвечает за текущую скорость
    public float gravity; // Ёта переменна€ отвечает за гравитацию

    private float moveSpeed;    // —корость ходьбы всегда хранитьс€ в отдельной переменной, а не перевычисл€етс€
    private float runSpeed;     // «аменил множитель на скорость бега
    
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
        if (_characteristics.HP > 0)
        {
            // я мог накос€чить с векотором movement, так как запуталс€, где кака€ скорость должна быть
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(deltaX * currentSpeed, 0, deltaZ * currentSpeed);
            movement = Vector3.ClampMagnitude(movement, currentSpeed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
            
            // TODO 1: «аменить волшебное число 0.1f на какую-нибудь переменную "отклонение скорости" или типа того
            // TODO 2: »нерцию персонажа. “о есть от ходьбы к бегу скорость мен€етс€ за несколько тактов и наоборот.
            if ((Mathf.Abs(deltaX) < 0.1f) && (Mathf.Abs(deltaZ) < 0.1f))
            {
                currentSpeed = 0;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    currentSpeed = runSpeed;
                }
                else
                {
                    currentSpeed = moveSpeed;
                }
            }

            // “еперь анимации idle / walk / run сами переключаютс€ в зависимости от параметра Speed
            _animator.SetFloat("Speed", currentSpeed);
        }

    }
}
