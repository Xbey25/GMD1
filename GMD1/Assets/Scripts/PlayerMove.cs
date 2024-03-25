using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement parameters
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float swingAmount = 0.1f;
    public float swingSpeed = 5f;

    // State variables
    private IPlayerState currentState;
    public IdleState IdleState { get; private set; }
    public MovingState MovingState { get; private set; }
    public RotatingState RotatingState { get; private set; }

    // Character controller and camera
    private CharacterController characterController;
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = transform.GetChild(0); // Assuming camera is the first child

        // Initialize states
        IdleState = new IdleState(this);
        MovingState = new MovingState(this);
        RotatingState = new RotatingState(this);

        // Set initial state
        currentState = IdleState;
    }

    void Update()
    {
        currentState.UpdateState();
    }

    // State transition methods
    public void TransitionToState(IPlayerState nextState)
    {
        currentState = nextState;
    }

    // Getters
    public CharacterController GetCharacterController()
    {
        return characterController;
    }

    public Transform GetCameraTransform()
    {
        return cameraTransform;
    }

    // Movement methods
    public void Move(float horizontal, float vertical)
    {
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontal, 0f, vertical));
        moveDirection *= moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(float mouseX)
    {
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }

    public void ApplySwing(float swing)
    {
        Vector3 swingOffset = new Vector3(0f, 0f, swing * swingAmount);
        cameraTransform.localPosition = swingOffset;
    }
}

// Interface for player states
public interface IPlayerState
{
    void UpdateState();
}

// Idle state
public class IdleState : IPlayerState
{
    private PlayerController playerController;

    public IdleState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        // Handle input to transition to other states
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            playerController.TransitionToState(playerController.MovingState);
        }
        else if (Input.GetAxis("Mouse X") != 0)
        {
            playerController.TransitionToState(playerController.RotatingState);
        }
    }
}

// Moving state
public class MovingState : IPlayerState
{
    private PlayerController playerController;

    public MovingState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        // Handle input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerController.Move(horizontal, vertical);

        // Transition to idle state if no movement input
        if (horizontal == 0 && vertical == 0)
        {
            playerController.TransitionToState(playerController.IdleState);
        }
    }
}

// Rotating state
public class RotatingState : IPlayerState
{
    private PlayerController playerController;

    public RotatingState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        // Handle input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        playerController.Rotate(mouseX);

        // Transition to idle state if no rotation input
        if (mouseX == 0)
        {
            playerController.TransitionToState(playerController.IdleState);
        }
    }
}
