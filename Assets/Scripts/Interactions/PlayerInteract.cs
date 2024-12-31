using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField] float distance = 3.0f; // Distance of the ray in front of the player.
    [SerializeField] LayerMask mask; // To only interact with objects a certain layer.

    private PlayerUI playerUI;
    private InputManager inputManager;

    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Create a ray in the direction the camera is facing at.
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitObject;

        // If we hit something from within the mask
        if (Physics.Raycast(ray, out hitObject, distance, mask))
        {
            Interactable interactableObject = hitObject.collider.GetComponent<Interactable>();

            // If the object has an Interactable component
            if (interactableObject != null)
            {
                // We display it's text via the UI
                playerUI.UpdateText(interactableObject.promptMessage);

                // If we try to interact with it - execute the Interaction method.
                if (inputManager.groundMovement.Interact.triggered)
                {
                    interactableObject.BaseInteract();
                }
            }
        }
    }
}
