using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float playerSpeed = 20f;
    private CharacterController player;
    private Vector3 movementVector;
    private float gravity = -10f;
    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector.x = (inputVector * playerSpeed) + (Vector3.up * gravity;)
    }

    void MovePlayer()
    {
        player.Move(player.transform.forward * playerSpeed * Time.deltaTime);
    }
}
