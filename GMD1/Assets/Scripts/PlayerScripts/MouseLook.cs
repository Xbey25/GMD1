using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public float snapCooldown = 0.5f; // Time in seconds between allowed snaps
    private float lastSnapTime = 0f;

    private PlayerControls inputActions;

    private float[] snapAnglesHorizontal = { -90f, 0f, 90f, 180f }; // Left, Forward, Right, Backward
    private int currentHorizontalIndex = 1; // Start looking forward

    void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Player.LookLeft.started += _ => SnapHorizontal(-1); // Snap left when button is pressed
        inputActions.Player.LookRight.started += _ => SnapHorizontal(1); // Snap right when button is pressed
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
        // Add cooldown logic here if needed
    }

    void SnapHorizontal(int direction)
    {
        currentHorizontalIndex = (currentHorizontalIndex + direction + snapAnglesHorizontal.Length) % snapAnglesHorizontal.Length;
        float targetAngle = snapAnglesHorizontal[currentHorizontalIndex];
        player.localEulerAngles = new Vector3(player.localEulerAngles.x, targetAngle, player.localEulerAngles.z);
    }
}
