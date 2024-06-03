using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NavKeypad
{
    public class KeypadInteractionFPV : MonoBehaviour
    {
        private Camera cam;
        private PlayerControls inputActions;
        private InputAction pickUpAction;

        private void Awake()
        {
            cam = Camera.main;
            inputActions = new PlayerControls();
            pickUpAction = inputActions.Player.PickUp;
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
        }

        private void OnDisable()
        {
            inputActions.Player.Disable();
        }

        private void Update()
        {
            if (pickUpAction.triggered)
            {
                var mousePosition = Mouse.current.position.ReadValue();
                var ray = cam.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        keypadButton.PressButton();
                    }
                }
            }
        }
    }
}
