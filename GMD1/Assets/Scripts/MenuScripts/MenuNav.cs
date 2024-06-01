using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MenuNav : MonoBehaviour
{
    public Button[] menuButtons; // Assign your buttons in the inspector
    private int selectedIndex = 0;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
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
        if (navigation.y > 0)
        {
            MoveUp();
        }
        else if (navigation.y < 0)
        {
            MoveDown();
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