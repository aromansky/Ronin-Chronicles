using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(deltaX, 0, deltaZ);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= speedMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= speedMultiplier;
        }
    }
}
