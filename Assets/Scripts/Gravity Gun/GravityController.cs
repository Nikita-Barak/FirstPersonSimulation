using UnityEngine;

public class GravityController : MonoBehaviour
{
    [Header("Component Variables")]
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform objectHolder; // An empty object infront of the player's camera, guiding the grabbed object through the air.
    [SerializeField] LayerMask grabbableObjects;

    [Header("Numeric Variables")]
    [SerializeField] float maxGrabDistance = 5f;
    [SerializeField] float throwForce = 20f;
    [SerializeField] float lerpSpeed = 20f;

    private InputManager inputManager;
    private Rigidbody grabbedRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we hold an object
        if (grabbedRB)
        {
            // We move it to the objectHolder's position constantly and smoothly (deppendant on the lerp speed)
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            // If we want to shoot our object, we throw it in the given force via the variable.
            if (inputManager.groundMovement.Shoot.triggered)
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }

        // If we try to grab an object
        if (inputManager.groundMovement.Interact.triggered)
        {
            // And hold one already - we just cancel the grab.
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }

            // And don't hold one yet - we try to see if we can grab an object.
            else
            {
                RaycastHit hit;
                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

                // If the ray caught a grabbable object, we grab it.
                if (Physics.Raycast(ray, out hit, maxGrabDistance, grabbableObjects))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}
