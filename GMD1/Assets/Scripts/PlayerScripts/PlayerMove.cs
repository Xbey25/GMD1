using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform; // Reference to the camera's transform

    private IPlayerState currentState;
    public IdleState IdleState { get; private set; }
    public MovingState MovingState { get; private set; }

    private CharacterController characterController;

    // Input actions
    private PlayerControls inputActions;
    private Vector2 moveInput;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        IdleState = new IdleState(this);
        MovingState = new MovingState(this);

        currentState = IdleState;

        inputActions = new PlayerControls();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void TransitionToState(IPlayerState nextState)
    {
        currentState = nextState;
    }

    public CharacterController GetCharacterController()
    {
        return characterController;
    }

    public void Move(float vertical)
    {
        Vector3 forward = cameraTransform.forward;

        // Normalize the direction on the XZ plane
        forward.y = 0;
        forward.Normalize();

        Vector3 moveDirection = forward * vertical;
        moveDirection *= moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }
}

public interface IPlayerState
{
    void UpdateState();
}

public class IdleState : IPlayerState
{
    private PlayerController playerController;

    public IdleState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        Vector2 moveInput = playerController.GetMoveInput();
        if (moveInput.y != 0) // Only transition if there is vertical input
        {
            playerController.TransitionToState(playerController.MovingState);
        }
    }
}

public class MovingState : IPlayerState
{
    private PlayerController playerController;

    public MovingState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        Vector2 moveInput = playerController.GetMoveInput();
        playerController.Move(moveInput.y); // Only use the vertical input

        if (moveInput.y == 0) // Transition to idle state if there is no vertical input
        {
            playerController.TransitionToState(playerController.IdleState);
        }
    }
}
