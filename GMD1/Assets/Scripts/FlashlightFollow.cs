using UnityEngine;

public class FollowCameraDirection : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, -0.5f, 1f); // Example offset values, adjust as needed
    private Transform cameraTransform;

    void Start()
    {
        // Find the main camera in the scene
        cameraTransform = Camera.main.transform;

        // Make sure the script doesn't affect the object's rotation
        transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        // Get the forward direction of the camera
        Vector3 cameraForward = cameraTransform.forward;

        // Project the forward direction onto the XZ plane (assuming Y is up)
        cameraForward.y = 0f;

        // Rotate the object to face the projected camera forward direction
        transform.rotation = Quaternion.LookRotation(cameraForward);

        // Apply the offset to position the flashlight in front of the camera
        transform.position = cameraTransform.position + cameraForward.normalized * offset.z + Vector3.up * offset.y;
    }
}
