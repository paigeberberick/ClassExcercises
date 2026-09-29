using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] ParticleSystem TestParticle;

    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if (Keyboard.current != null)
        {
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
        }

        // Rotate the player
        transform.Rotate(0, 0, steer * steerSpeed * Time.deltaTime);

        // Move the player forward/backward
        transform.Translate(
            0,
            move * moveSpeed * Time.deltaTime,
            0
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            // Do something when hitting Trigger
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            if (TestParticle != null)
            {
                TestParticle.Play();
            }
        }
    }
}

