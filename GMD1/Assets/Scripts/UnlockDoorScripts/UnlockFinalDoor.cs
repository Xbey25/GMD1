using UnityEngine;

public class UnlockFinalDoor : MonoBehaviour
{
    public Animator doorAnim; // Assign the door's Animator component in the Inspector

    public Transform player;

    private PlayerControls inputActions;
    public EndMenuNav wonMenuNav;
    public Canvas wonScreen;


    void Start()
    {
        
        if (doorAnim == null)
        {
            Debug.LogError("Door Animator is not assigned!");
        }
    }

    void Update()
    {
        if (doorAnim != null)
        {
            AnimatorStateInfo stateInfo = doorAnim.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("DoorOpen"))
            {
                player.gameObject.GetComponent<PlayerController>().enabled = false;
                player.GetComponentInChildren<Camera>().GetComponent<MouseLook>().enabled = false;
                wonScreen.enabled = true;
                wonMenuNav.ResumeMovement();
            }
        }
    }
}
