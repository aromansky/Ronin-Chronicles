using System.Linq;
using UnityEngine;

public class MouseLookCam : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor;
    public float sensitivityVert;

    private PlayerCharacteristics _characteristics;
    public float minimumVert;
    public float maximumVert;
    private float _rotationX = 0;


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
        _characteristics = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (_characteristics.HP <= 0)
                axes = RotationAxes.MouseXandY;

            if (axes == RotationAxes.MouseX)
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }

            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor; // приращение угла поворота

                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}


