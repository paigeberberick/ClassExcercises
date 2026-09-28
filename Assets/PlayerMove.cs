using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float steerSpeed = .5f;
    [SerializeField] float moveSpeed = 0.1f;


    // Update is called once per frame
    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }

        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        transform.Rotate(0, 0, steer * steerSpeed * Time.deltaTime);
        transform.Translate(0, move * moveSpeed * Time.deltaTime, 0);
    }
}

