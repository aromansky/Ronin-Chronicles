using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private float speed;
    private float speedMultiplier;
    private float gravity;
    private PlayerCharacteristics _characteristics;
    private CharacterController _charController;
    private Animator _animator;

    private void Start()
    {
        speed = GetComponent<PlayerCharacteristics>().speed;
        speedMultiplier = GetComponent<PlayerCharacteristics>().speedMultiplier;
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
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, gravity, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= speedMultiplier;
                _animator.SetBool("Run", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed /= speedMultiplier;
                _animator.SetBool("Run", false);
            }

            if (deltaX != 0 || deltaZ != 0)
            {
                _animator.SetBool("Move", true);
            }
            else
            {
                _animator.SetBool("Move", false);
            }
        }

    }
}
