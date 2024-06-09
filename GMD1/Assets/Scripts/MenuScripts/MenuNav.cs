using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuNav : MonoBehaviour
{
    public Button[] menuButtons;
    private int selectedIndex = 0;

    private PlayerControls controls;
    private const float deadZoneThreshold = 0.5f; // Higher threshold for the dead zone
    private const float snapCooldownDuration = 0.2f; // Duration of the snap cooldown in seconds
    private float lastSnapTime = 0f; // Time when the last snap occurred

    private void Awake()
    {
        controls = new PlayerControls();
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].interactable = (i == selectedIndex);
        }
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
        controls.Menu.Navigate.performed += OnNavigate;
        controls.Menu.Select.performed += OnSelect;
    }

    private void OnDisable()
    {
        controls.Menu.Navigate.performed -= OnNavigate;
        controls.Menu.Select.performed -= OnSelect;
        controls.Menu.Disable();
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 navigation = context.ReadValue<Vector2>();
        float currentTime = Time.time; // Get the current time

        if (navigation.magnitude > deadZoneThreshold && currentTime - lastSnapTime >= snapCooldownDuration)
        {
            if (navigation.y > 0)
            {
                MoveUp();
            }
            else if (navigation.y < 0)
            {
                MoveDown();
            }
            lastSnapTime = currentTime; // Update the last snap time
        }
    }

    private void OnSelect(InputAction.CallbackContext context)
    {
        menuButtons[selectedIndex].onClick.Invoke();
    }

    private void MoveUp()
    {
        selectedIndex = (selectedIndex - 1 + menuButtons.Length) % menuButtons.Length;
        UpdateButtonSelection();
    }

    private void MoveDown()
    {
        selectedIndex = (selectedIndex + 1) % menuButtons.Length;
        UpdateButtonSelection();
    }

    private void UpdateButtonSelection()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].interactable = (i == selectedIndex);
        }
    }
}