using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1.5f;
    public float smoothing = 2f;

    private float xMousePosition;
    private float yMousePosition;

    private float smoothedXMousePosition;
    private float smoothedYMousePosition;


    private float currentXLookingPosition;
    private float currentYLookingPosition;

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
        yMousePosition = Input.GetAxisRaw("Mouse Y");

    }

    void ModifyInput()
    {
        xMousePosition *= mouseSensitivity * smoothing;
        
          xMousePosition *= mouseSensitivity * smoothing;
        yMousePosition *= mouseSensitivity * smoothing;

        smoothedXMousePosition = Mathf.Lerp(smoothedXMousePosition, xMousePosition, 1f / smoothing);
        smoothedYMousePosition = Mathf.Lerp(smoothedYMousePosition, yMousePosition, 1f / smoothing);

        currentXLookingPosition += smoothedXMousePosition;
        currentYLookingPosition -= smoothedYMousePosition;
    }

    void MovePlayer()
    {
                transform.localRotation = Quaternion.Euler(currentYLookingPosition, currentXLookingPosition, 0f);

    }
}
