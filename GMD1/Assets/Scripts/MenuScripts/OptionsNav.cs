using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsMenuNav : MonoBehaviour
{
    public Button backButton;
    public Slider brightnessSlider;

    private Selectable[] menuElements;
    private int selectedIndex = 0;

    private PlayerControls controls;
    private const float deadZoneThreshold = 0.8f; // Higher threshold for the dead zone
    private const float snapCooldownDuration = 0.2f; // Duration of the snap cooldown in seconds
    private float lastSnapTime = 0f; // Time when the last snap occurred

    private void Awake()
    {
        controls = new PlayerControls();
        // Initialize the array with the back button and the brightness slider
        menuElements = new Selectable[] { backButton, brightnessSlider };
        for (int i = 0; i < menuElements.Length; i++)
        {
            menuElements[i].interactable = (i == selectedIndex);
        }
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
        controls.Menu.Navigate.performed += OnNavigate;
        controls.Menu.Select.performed += OnSelect;
        controls.Menu.Slide.performed += OnSlide;
    }

    private void OnDisable()
    {
        controls.Menu.Navigate.performed -= OnNavigate;
        controls.Menu.Select.performed -= OnSelect;
        controls.Menu.Slide.performed -= OnSlide;
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
    float inputValue = context.ReadValue<float>();
    
    // Check if input value exceeds deadzone threshold
    if (Mathf.Abs(inputValue) > deadZoneThreshold)
    {
        // If input value is non-zero, make selection
        if (Time.time - lastSnapTime >= snapCooldownDuration)
        {
            if (menuElements[selectedIndex] is Button button)
            {
                button.onClick.Invoke();
            }
            lastSnapTime = Time.time; // Update the last snap time
        }
    }
}



   private void OnSlide(InputAction.CallbackContext context)
{
    if (menuElements[selectedIndex] is Slider slider)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        float sensitivity = 0.5f; // Adjust the sensitivity as needed
        slider.value += delta.x * sensitivity;
    }
}


    private void MoveUp()
    {
        selectedIndex = (selectedIndex - 1 + menuElements.Length) % menuElements.Length;
        UpdateSelection();
    }

    private void MoveDown()
    {
        selectedIndex = (selectedIndex + 1) % menuElements.Length;
        UpdateSelection();
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < menuElements.Length; i++)
        {
            if (menuElements[i] is Button button)
            {
                button.interactable = (i == selectedIndex);
            }
            else if (menuElements[i] is Slider slider)
            {
                slider.interactable = (i == selectedIndex);
            }
        }

        menuElements[selectedIndex].Select();
    }
}
