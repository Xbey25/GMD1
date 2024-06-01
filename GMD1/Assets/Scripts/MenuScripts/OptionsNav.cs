using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsNav : MonoBehaviour
{
    public Slider brightnessSlider;
    public Button backButton;
    private PlayerControls controls;
    private bool adjustingBrightness = false;
    private const float brightnessChangeSpeed = 0.1f;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
        controls.Menu.Navigate.performed += OnNavigate;
        controls.Menu.Slide.performed += OnSlide;
        controls.Menu.Select.performed += OnSelect;
    }

    private void OnDisable()
    {
        controls.Menu.Navigate.performed -= OnNavigate;
        controls.Menu.Slide.performed -= OnSlide;
        controls.Menu.Select.performed -= OnSelect;
        controls.Menu.Disable();
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 navigation = context.ReadValue<Vector2>();

        if (!adjustingBrightness)
        {
            if (navigation.y != 0)
            {
                // Toggle between adjusting brightness and selecting back button
                adjustingBrightness = !adjustingBrightness;
                UpdateSliderSelection(adjustingBrightness);
            }
        }
        else
        {
            // If adjusting brightness, handle brightness change
            float slideAmount = navigation.y * brightnessChangeSpeed;
            brightnessSlider.value = Mathf.Clamp(brightnessSlider.value + slideAmount, brightnessSlider.minValue, brightnessSlider.maxValue);
        }
    }

    private void OnSelect(InputAction.CallbackContext context)
    {
        if (!adjustingBrightness)
        {
            // Handle selection if not adjusting brightness
            backButton.onClick.Invoke();
        }
    }

    private void OnSlide(InputAction.CallbackContext context)
    {
        // Handle brightness adjustment using the Slide input action
        if (adjustingBrightness)
        {
            // Read the value of individual keys ("a" and "d") from the context
            float slideAmount = 0f;
            if (context.control.name == "a")
            {
                slideAmount = -1f; // Decrease brightness
            }
            else if (context.control.name == "d")
            {
                slideAmount = 1f; // Increase brightness
            }

            // Adjust brightness slider value based on the slide amount
            brightnessSlider.value = Mathf.Clamp(brightnessSlider.value + slideAmount * brightnessChangeSpeed, brightnessSlider.minValue, brightnessSlider.maxValue);
        }
    }

    private void UpdateSliderSelection(bool isSelected)
    {
        brightnessSlider.interactable = isSelected;
        backButton.interactable = !isSelected;
    }
}
