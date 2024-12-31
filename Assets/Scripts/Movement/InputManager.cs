using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    public InputSystem_Actions.GroundMovementActions groundMovement;
    private PlayerMover mover;
    private PlayerLook looker;

    private void Awake()
    {
        playerInput = new InputSystem_Actions();
        groundMovement = playerInput.GroundMovement;
        mover = GetComponent<PlayerMover>();
        looker = GetComponent<PlayerLook>();

        // Context usage - we use a context reference to activate the PlayerMover's Jump() method whenever jump is pressed.
        groundMovement.Jump.performed += ctx => mover.Jump();
    }

    private void FixedUpdate()
    {
        if (groundMovement.Run.IsPressed())
        {
            mover.isRunning = true;
        }
        else
        {
            mover.isRunning = false;
        }

        mover.HandleMovement(groundMovement.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        looker.HandleLooking(groundMovement.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        groundMovement.Enable();
    }

    private void OnDisable()
    {
        groundMovement.Disable();
    }
}
