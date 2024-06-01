using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

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

    public void Move(float horizontal, float vertical)
    {
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
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
        if (moveInput != Vector2.zero)
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
        playerController.Move(moveInput.x, moveInput.y);

        if (moveInput == Vector2.zero)
        {
            playerController.TransitionToState(playerController.IdleState);
        }
    }
}
