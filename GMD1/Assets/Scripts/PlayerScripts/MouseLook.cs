using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1.5f;
    public float smoothing = 2f;

    private float xMousePosition;
    private float smoothedMousePosition;

    private float currentLookingPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePosition = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePosition *= mouseSensitivity * smoothing;
        smoothedMousePosition = Mathf.Lerp(smoothedMousePosition, xMousePosition, 1f / smoothing);
        currentLookingPosition += smoothedMousePosition;
    }

    void MovePlayer()
    {
        currentLookingPosition += smoothedMousePosition;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPosition, transform.up);
    }
}
