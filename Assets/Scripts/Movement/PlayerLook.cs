using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public Camera playerCamera;

    private float xAxisRotation = 0f;

    [Header("Sensitivity settings")]
    [SerializeField] float xSensitivity = 30f;
    [SerializeField] float ySensitivity = 30f;

    [Header("Camera rotation speed boundaries.")]
    [SerializeField] float minClamp = -80f;
    [SerializeField] float maxClamp = 80f;

    public void HandleLooking(Vector2 input)
    {
        float mouseXInput = input.x;
        float mouseYInput = input.y;

        // Calculate rotation data.
        xAxisRotation -= mouseYInput * Time.deltaTime * ySensitivity;
        xAxisRotation = Mathf.Clamp(xAxisRotation, minClamp, maxClamp);

        // Change the camera's transformation.
        playerCamera.transform.localRotation = Quaternion.Euler(xAxisRotation, 0, 0);

        // Rotate the player's PoV.
        transform.Rotate(Vector3.up * (mouseXInput * Time.deltaTime * xSensitivity));
    }
}
