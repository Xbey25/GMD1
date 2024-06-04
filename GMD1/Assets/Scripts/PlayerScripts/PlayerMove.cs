using UnityEngine;
using UnityEngine.InputSystem;

// This script has movement, stamina, and health mechanics, they are implemented in a state pattern, kinda similar to coroutines
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public Transform cameraTransform; 

    private IPlayerState currentState;
    public IdleState IdleState { get; private set; }
    public MovingState MovingState { get; private set; }
    public SprintingState SprintingState { get; private set; }

    private CharacterController characterController;
    private PlayerStats playerStats; 

    // Input actions for player movement
    private PlayerControls inputActions;
    private Vector2 moveInput;
    private bool isSprinting;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>(); 

        IdleState = new IdleState(this);
        MovingState = new MovingState(this);
        SprintingState = new SprintingState(this);

        currentState = IdleState;

        inputActions = new PlayerControls();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Player.Sprint.performed += ctx => isSprinting = true;
        inputActions.Player.Sprint.canceled += ctx => isSprinting = false;
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

    public void Move(float vertical, bool sprinting)
    {
        Vector3 forward = cameraTransform.forward;

        forward.y = 0;
        forward.Normalize();

        Vector3 moveDirection = forward * vertical;
        moveDirection *= sprinting ? sprintSpeed : moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }

    public bool IsSprinting()
    {
        return isSprinting;
    }

    public PlayerStats GetPlayerStats()
    {
        return playerStats;
    }
}

public interface IPlayerState
{
    void UpdateState();
}

public class IdleState : IPlayerState
{
    private PlayerController playerController;
    private float staminaRegenerationRate = 5f; // Stamina regenerates when idle

    public IdleState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        Vector2 moveInput = playerController.GetMoveInput();
        if (moveInput.y != 0) 
        {
            if (playerController.IsSprinting() && playerController.GetPlayerStats().currentStamina > 0)
            {
                playerController.TransitionToState(playerController.SprintingState);
            }
            else
            {
                playerController.TransitionToState(playerController.MovingState);
            }
        }
        else
        {
            playerController.GetPlayerStats().AdjustStamina(staminaRegenerationRate * Time.deltaTime);
        }
    }
}

public class MovingState : IPlayerState
{
    private PlayerController playerController;
    private float staminaRegenerationRate = 5f; // Stamina regenerates when moving

    public MovingState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        Vector2 moveInput = playerController.GetMoveInput();
        playerController.Move(moveInput.y, false);

        if (moveInput.y == 0)
        {
            playerController.TransitionToState(playerController.IdleState);
        }
        else if (playerController.IsSprinting() && playerController.GetPlayerStats().currentStamina > 0)
        {
            playerController.TransitionToState(playerController.SprintingState);
        }
        else
        {
            playerController.GetPlayerStats().AdjustStamina(staminaRegenerationRate * Time.deltaTime);
        }
    }
}

public class SprintingState : IPlayerState
{
    private PlayerController playerController;
    private float staminaReductionRate = 10f; // stamina reduces when running

    public SprintingState(PlayerController controller)
    {
        playerController = controller;
    }

    public void UpdateState()
    {
        Vector2 moveInput = playerController.GetMoveInput();
        playerController.Move(moveInput.y, true); 

        playerController.GetPlayerStats().AdjustStamina(-staminaReductionRate * Time.deltaTime);

        if (moveInput.y == 0) // move to idle when no vertical input, idle does nothing though
        {
            playerController.TransitionToState(playerController.IdleState);
        }
        else if (!playerController.IsSprinting() || playerController.GetPlayerStats().currentStamina <= 0)
        {
            playerController.TransitionToState(playerController.MovingState);
        }
    }
}
