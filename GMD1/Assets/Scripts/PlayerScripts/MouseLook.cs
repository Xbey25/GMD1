using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private PlayerControls inputActions;
    private Vector2 lookInput;

    void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        float inputX = lookInput.x * mouseSensitivity;
        float inputY = lookInput.y * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);

        float movement = Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"));
        float bobAmountThisFrame = Mathf.Sin(Time.time * bobSpeed) * bobAmount;

        Vector3 newPos = transform.localPosition;
        newPos.y = defaultPosY + bobAmountThisFrame * movement;
        transform.localPosition = newPos;
    }
}
