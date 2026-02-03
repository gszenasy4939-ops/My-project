using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float targetSpeed = 5f;
    [SerializeField] private float acceleration = 25f;
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rigidbody;
    private float moveInput;


    public void OnMove(InputAction.CallbackContext context)
    { 
        Debug.Log("Moved");
        moveInput = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jumped");
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float targetVelocityX = moveInput * targetSpeed;
        rigidbody.linearVelocityX = Mathf.MoveTowards(rigidbody.linearVelocityX, targetVelocityX, acceleration * Time.fixedDeltaTime);
    }
}
