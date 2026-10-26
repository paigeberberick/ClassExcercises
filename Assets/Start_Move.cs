using UnityEngine;
using UnityEngine.InputSystem;

public class Start_Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 12f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDistance = 0.05f;

    Vector2 movePlayer;
    Rigidbody2D rb;
    Collider2D playerCollider;
    bool hasPlayerInputMove;
    bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Read the key press here, since wasPressedThisFrame is unreliable in FixedUpdate
        if (Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame)
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        // Fallback: read keyboard directly (bypasses Player Input)
        if (Keyboard.current != null)
        {
            float x = 0;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1;

            if (x != 0) movePlayer = new Vector2(x, 0);
            else if (!hasPlayerInputMove) movePlayer = Vector2.zero;
        }

        float yVelocity = rb.linearVelocity.y;

        if (jumpRequested && IsGrounded())
            yVelocity = jumpSpeed;

        jumpRequested = false;

        rb.linearVelocity = new Vector2(movePlayer.x * moveSpeed, yVelocity);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            playerCollider.bounds.center,
            playerCollider.bounds.size,
            0f,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );
        return hit.collider != null;
    }

    public void OnMove(InputValue value)
    {
        movePlayer = value.Get<Vector2>();
        hasPlayerInputMove = movePlayer != Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
            Debug.Log("Triggered Hazard!");
    }
}