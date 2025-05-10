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
    [SerializeField] float freezeTime = 3f;
    [SerializeField] float knockbackForce = 10f;

    Vector2 knockbackVector;

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
            rb.linearVelocity = new Vector2(-horizontalMovement * moveSpeed, rb.linearVelocityY) + knockbackVector;
            //rb.position += new Vector2(-horizontalMovement * moveSpeed * Time.fixedDeltaTime, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocityY) + knockbackVector;
            //rb.position += new Vector2(horizontalMovement * moveSpeed * Time.fixedDeltaTime, rb.linearVelocityY);
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

        knockbackVector = Vector2.Lerp(knockbackVector, Vector2.zero, 1 * Time.deltaTime);
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
        yield return new WaitForSecondsRealtime(freezeTime);
        freeze = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "P1" || collision.tag == "P2")
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            knockbackVector = new Vector2(direction.x * knockbackForce, direction.y * knockbackForce * 0.01f);
        }
    }
}
