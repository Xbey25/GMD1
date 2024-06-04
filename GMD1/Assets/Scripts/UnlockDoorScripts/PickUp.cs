using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public KeyInventory _keyInventory = null;
    public Image redKeyUI;
    public Image greenKeyUI;
    public Image yellowKeyUI;

    public GameObject redKey;
    public GameObject greenKey;
    public GameObject yellowKey;

    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.PickUp.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputActions.Player.PickUp.performed -= OnInteract;
        inputActions.Player.Disable();
    }

    private void Start()
    {
        redKeyUI.enabled = false;
        yellowKeyUI.enabled = false;
        greenKeyUI.enabled = false;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Pickable"))
            {
                PickUpObject(hitObject);
            }
        }
    }

    void PickUpObject(GameObject obj)
    {
        if (obj == redKey)
        {
            _keyInventory.hasRedKey = true;
            redKeyUI.enabled = true;
            redKey.SetActive(false);
        }

        if (obj == greenKey)
        {
            _keyInventory.hasGreenKey = true;
            greenKeyUI.enabled = true;
            greenKey.SetActive(false);
        }

        if (obj == yellowKey)
        {
            _keyInventory.hasYellowKey = true;
            yellowKeyUI.enabled = true;
            yellowKey.SetActive(false);
        }
    }
}
