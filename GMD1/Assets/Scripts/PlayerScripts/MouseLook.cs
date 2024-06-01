using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    public float snapCooldown = 0.5f; // Time in seconds between allowed snaps
    private float lastSnapTime = 0f;

    private PlayerControls inputActions;
    private Vector2 lookInput;

    private float[] snapAnglesHorizontal = { -90f, 0f, 90f, 180f }; // Left, Forward, Right, Backward
    private float[] snapAnglesVertical = { -90f, 0f, 90f }; // Down, Center, Up
    private int currentHorizontalIndex = 1; // Start looking forward
    private int currentVerticalIndex = 1; // Start looking center

    private float deadZone = 0.5f; // Dead zone for joystick input

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
    }

    void Update()
    {
        if (Time.time - lastSnapTime >= snapCooldown)
        {
            if (Mathf.Abs(lookInput.x) > deadZone)
            {
                SnapHorizontal(lookInput.x);
                lastSnapTime = Time.time;
            }
            if (Mathf.Abs(lookInput.y) > deadZone)
            {
                SnapVertical(lookInput.y);
                lastSnapTime = Time.time;
            }
        }
    }

    void SnapHorizontal(float inputX)
    {
        if (inputX > 0)
        {
            currentHorizontalIndex = (currentHorizontalIndex + 1) % snapAnglesHorizontal.Length;
        }
        else if (inputX < 0)
        {
            currentHorizontalIndex = (currentHorizontalIndex - 1 + snapAnglesHorizontal.Length) % snapAnglesHorizontal.Length;
        }

        float targetAngle = snapAnglesHorizontal[currentHorizontalIndex];
        player.localEulerAngles = new Vector3(player.localEulerAngles.x, targetAngle, player.localEulerAngles.z);
    }

    void SnapVertical(float inputY)
    {
        if (inputY > 0)
        {
            currentVerticalIndex = Mathf.Clamp(currentVerticalIndex + 1, 0, snapAnglesVertical.Length - 1);
        }
        else if (inputY < 0)
        {
            currentVerticalIndex = Mathf.Clamp(currentVerticalIndex - 1, 0, snapAnglesVertical.Length - 1);
        }

        float targetAngle = snapAnglesVertical[currentVerticalIndex];
        transform.localEulerAngles = new Vector3(targetAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
