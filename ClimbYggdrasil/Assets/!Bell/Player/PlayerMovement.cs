using System.Collections;
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

    [SerializeField] Camera cam;

    float horizontalMovement;

    bool isFacingRight = true;

    [Header("Fuck for players")]
    bool invert = false;
    bool freeze = false;
    [SerializeField] float invertTime = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (playerIndex == 0)
        {
            cam.rect = new Rect(0, 0, 0.5f, 1);
        }
        else if (playerIndex == 1)
        {
            cam.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
    }
    private void FixedUpdate()
    {
        if (invert)
        {
            rb.linearVelocity = new Vector2(-horizontalMovement * moveSpeed, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocityY);
        }
    }
    private void Update()
    {
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
        if (!freeze)
        {
            horizontalMovement = context.ReadValue<Vector2>().x;
        }
        else
        {
            horizontalMovement = 0;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded() && !freeze)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            FindFirstObjectByType<AudioManager>().Play("Jump");
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //fuck for players
    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void InvertControlls()
    {
        StartCoroutine(Invert());
    }

    IEnumerator Invert()
    {
        invert = true;
        yield return new WaitForSecondsRealtime(invertTime);
        invert = false;
    }

    public void Respawn()
    {
        transform.position = Vector3.zero;
    }
    public void FreezePlayer()
    {
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        freeze = true;
        yield return new WaitForSecondsRealtime(invertTime);
        freeze = false;
    }
}
