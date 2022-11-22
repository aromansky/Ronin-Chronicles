using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;
    public float gravity;

    private CharacterController _charController;
    private Animator _animator;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        gravity *= gravity < 0 ? 1: -1;
    }

    void Update()
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
