using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] int playerIndex = 0;

    float horizontalMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    //public int GetPlayerIndex()
    //{
    //    return playerIndex;
    //}
    //public void SetInputVector(Vector2 value)
    //{
    //    horizontalMovement = value.x;
    //}
}
