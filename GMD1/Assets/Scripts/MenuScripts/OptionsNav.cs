using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsNav : MonoBehaviour
{
    public Slider brightnessSlider;
    public Button backButton;
    private PlayerControls controls;
    private const float deadZoneThreshold = 0.5f;
    private const float snapCooldownDuration = 0.2f;
    private float lastSnapTime = 0f;
    private bool adjustingBrightness = false;

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
        float currentTime = Time.time;

        if (navigation.magnitude > deadZoneThreshold && currentTime - lastSnapTime >= snapCooldownDuration)
        {
            if (!adjustingBrightness)
            {
                if (navigation.y != 0)
                {
                    adjustingBrightness = true;
                    UpdateSliderSelection(true);
                }
            }
            else
            {
                if (navigation.x != 0)
                {
                    adjustingBrightness = false;
                    UpdateSliderSelection(false);
                }
            }
            lastSnapTime = currentTime;
        }
    }

    private void OnSlide(InputAction.CallbackContext context)
    {
        if (adjustingBrightness)
        {
            float slideAmount = context.ReadValue<Vector2>().x;
            brightnessSlider.value = Mathf.Clamp(brightnessSlider.value + slideAmount, brightnessSlider.minValue, brightnessSlider.maxValue);
        }
    }

    private void OnSelect(InputAction.CallbackContext context)
    {
        if (!adjustingBrightness)
        {
            backButton.onClick.Invoke();
        }
    }

    private void UpdateSliderSelection(bool isSelected)
    {
        brightnessSlider.interactable = isSelected;
        backButton.interactable = !isSelected;
    }
}
