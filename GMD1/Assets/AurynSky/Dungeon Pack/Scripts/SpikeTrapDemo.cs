using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour
{
    public Animator spikeTrapAnim; 

    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
        StopCoroutine(OpenCloseTrap());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is the player
        {
            Debug.Log("Player entered trigger collider.");
            StartCoroutine(OpenCloseTrap());
        }
    }

    IEnumerator OpenCloseTrap()
    {
        spikeTrapAnim.SetTrigger("open");
        Debug.Log("Playing open animation.");
        yield return new WaitForSeconds(3.0f);
        spikeTrapAnim.SetTrigger("close");
        Debug.Log("Playing close animation.");
    }
}
