using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Canvas tutorial;
    public Transform player; // Reference to the player's Transform

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.enabled = true;
        initialPosition = player.position; // Store the initial position of the player
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player's position has changed
        if (player.position != initialPosition)
        {
            tutorial.enabled = false; // Disable the tutorial Canvas
            this.enabled = false; // Optionally, disable this script if no longer needed
        }
    }
}
