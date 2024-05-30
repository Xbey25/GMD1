using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    public float bobAmount = 0.1f; // Amount of head bobbing
    public float bobSpeed = 10f; // Speed of head bobbing
    private float defaultPosY;
    float cameraVerticalRotation = 0f;
    bool lockedCursor = true;

    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        // Collect Mouse Input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the Camera around its local X axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        // Rotate the Player Object around its Y axis
        player.Rotate(Vector3.up * inputX);

        // Head bobbing effect
        float movement = Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"));
        float bobAmountThisFrame = Mathf.Sin(Time.time * bobSpeed) * bobAmount;

        // Apply head bobbing effect
        Vector3 newPos = transform.localPosition;
        newPos.y = defaultPosY + bobAmountThisFrame * movement;
        transform.localPosition = newPos;
    }
}
