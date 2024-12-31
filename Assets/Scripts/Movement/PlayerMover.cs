using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 velocity;
    private bool onGround = false;
    public bool isRunning = false;

    [Header("Speed Variables")]
    [SerializeField] float speed = 5.0f;
    [SerializeField] float runFactor = 1.5f;

    [Header("Gravitation Variables")]
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float minYVelocity = -2.0f;

    [Header("Jump Variables")]
    [SerializeField] float jumpHeight = 1.5f;
    [SerializeField] float jumpNegativeFactor = -3.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = controller.isGrounded;
    }

    // Receive movement vector in the plane from our InputManager component, and apply the needed movement on the player.
    public void HandleMovement(Vector2 input)
    {
        // Handle plane movement.
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y; // Converting 'Up' and 'Down' controls to control the Z-Axis movement instead of Y-Axis movement.
        controller.Move(transform.TransformDirection(moveDirection) * (isRunning ? speed * runFactor : speed) * Time.deltaTime);

        // Apply gravitational force at all times, but cupping the Y-Axis velocity to be no less than what's set in the minYVelocity variable.
        velocity.y += gravity * Time.deltaTime;
        if (onGround && velocity.y < 0)
        {
            velocity.y = minYVelocity;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (onGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * jumpNegativeFactor * gravity); // Simple force application upwards.
        }
    }
}
