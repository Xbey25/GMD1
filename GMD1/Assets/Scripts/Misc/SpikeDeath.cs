using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    public Animator spikeTrapAnim;
    public Transform player;

    private PlayerControls inputActions;
    public EndMenuNav wonMenuNav;
    public Canvas wonScreen;


    void Start()
    {
        AnimatorStateInfo stateInfo = spikeTrapAnim.GetCurrentAnimatorStateInfo(0);

    }
    void Awake()
    {
        AnimatorStateInfo stateInfo = spikeTrapAnim.GetCurrentAnimatorStateInfo(0);
        StopCoroutine(Die());
    }



    void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = spikeTrapAnim.GetCurrentAnimatorStateInfo(0);
        if (other.CompareTag("Player") && stateInfo.IsName("Open Trap")) // Check if the collider is the player
        {

            Debug.Log("Player entered trigger collider.");
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        player.GetComponentInChildren<Camera>().GetComponent<MouseLook>().enabled = false;
        wonScreen.enabled = true;
        wonMenuNav.ResumeMovement();

        yield return new WaitForSeconds(3.0f);
        
    }

}