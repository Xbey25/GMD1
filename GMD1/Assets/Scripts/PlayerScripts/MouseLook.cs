using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform; // Reference to the camera transform for vertical rotation
    public float rotationSpeed = 90f; // Degrees per second

    private PlayerControls inputActions;
    private float horizontalRotationInput = 0f;
    private float verticalRotationInput = 0f;

    void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Player.LookLeft.started += _ => horizontalRotationInput = -1f; // Start rotating left
        inputActions.Player.LookLeft.canceled += _ => horizontalRotationInput = 0f; // Stop rotating
        inputActions.Player.LookRight.started += _ => horizontalRotationInput = 1f; // Start rotating right
        inputActions.Player.LookRight.canceled += _ => horizontalRotationInput = 0f; // Stop rotating
        inputActions.Player.LookUp.started += _ => verticalRotationInput = -1f; // Start rotating up
        inputActions.Player.LookUp.canceled += _ => verticalRotationInput = 0f; // Stop rotating
        inputActions.Player.LookDown.started += _ => verticalRotationInput = 1f; // Start rotating down
        inputActions.Player.LookDown.canceled += _ => verticalRotationInput = 0f; // Stop rotating
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
        if (horizontalRotationInput != 0f)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime * horizontalRotationInput;
            player.Rotate(Vector3.up, rotationAmount);
        }

        if (verticalRotationInput != 0f)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime * verticalRotationInput;
            cameraTransform.Rotate(Vector3.right, rotationAmount);
        }
    }
}
