using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    [Tooltip("�������� ��������� � ������ ������ (�/�)")]
    public float currentSpeed = 0f; // ������ ��� ���������� �������� �� ������� ��������
    public float gravity; // ��� ���������� �������� �� ����������

    private float moveSpeed;    // �������� ������ ������ ��������� � ��������� ����������, � �� ���������������
    private float runSpeed;     // ������� ��������� �� �������� ����
    
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
            // � ��� ���������� � ��������� movement, ��� ��� ���������, ��� ����� �������� ������ ����
            // P.S � �������. ������� ����� ��������� �� ���������� � ������� ������ �����������. ��� � ����� �������� {}
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(deltaX * currentSpeed, 0, deltaZ * currentSpeed);
            movement = Vector3.ClampMagnitude(movement, currentSpeed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);

            // TODO 1: �������� ��������� ����� 0.1f �� �����-������ ���������� "���������� ��������" ��� ���� ����
            // TODO 2: ������� ���������. �� ���� �� ������ � ���� �������� �������� �� ��������� ������ � ��������.
            if ((Mathf.Abs(deltaX) < 0.1f) && (Mathf.Abs(deltaZ) < 0.1f))
                currentSpeed = 0;
            else
                if (Input.GetKey(KeyCode.LeftShift))
                    currentSpeed = runSpeed;
                else
                    currentSpeed = moveSpeed;

            // ������ �������� idle / walk / run ���� ������������� � ����������� �� ��������� Speed
            _animator.SetFloat("Speed", currentSpeed);
        }

    }
}
