using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 1f;

    [SerializeField] int playerIndex = 0;

    float horizontalMovement;

    bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (playerIndex == 0)
        {
            GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        }
        else if (playerIndex == 1)
        {
            GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
        }
    }
    private void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocityY);
        if (!isFacingRight && horizontalMovement > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontalMovement < 0f)
        {
            Flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocityX));

        animator.SetBool("Jump", !IsGrounded());
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
