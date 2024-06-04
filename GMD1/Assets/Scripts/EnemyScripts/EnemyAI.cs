using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;
    public EndMenuNav endMenuNav;
    public Canvas endScreen;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
        Debug.Log("Starting walking. Initial destination: " + currentDest.position);

        // Set initial destination and speed
        ai.destination = currentDest.position;
        ai.speed = walkSpeed;
        ai.isStopped = false;
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
                Debug.Log("Player detected. Starting chase.");
            }
        }

        if (chasing == true)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("sprint");
            Debug.Log("Chasing player. Setting destination to player position: " + dest);
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                player.gameObject.GetComponent<PlayerController>().enabled = false;
                player.GetComponentInChildren<Camera>().GetComponent<MouseLook>().enabled = false;
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("idle");
                aiAnim.ResetTrigger("sprint");
                aiAnim.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                endScreen.enabled = true;
                endMenuNav.ResumeMovement();
                chasing = false;
                Debug.Log("Player caught. Triggering jumpscare.");
            }
        }

        if (walking == true)
        {
            if (!aiAnim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("idle");
                aiAnim.SetTrigger("walk");
                Debug.Log("Set walk animation trigger.");
            }

            // Check remaining distance to destination
            float remainingDistance = ai.remainingDistance;
            float stoppingDistance = ai.stoppingDistance;
            Debug.Log("Walking to destination: " + dest + ", Remaining distance: " + remainingDistance + ", Stopping distance: " + stoppingDistance);

            if (remainingDistance <= stoppingDistance && !ai.pathPending)
            {
                aiAnim.ResetTrigger("run");
                aiAnim.ResetTrigger("sprint");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
                Debug.Log("Reached destination. Going idle.");
            }
        }
    }

    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        Debug.Log("Idle for " + idleTime + " seconds.");
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
        Debug.Log("Idle finished. New destination: " + currentDest.position);

        // Set new destination and speed
        ai.destination = currentDest.position;
        ai.speed = walkSpeed;
        ai.isStopped = false;
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        Debug.Log("Chase for " + chaseTime + " seconds.");
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
        Debug.Log("Chase finished. New destination: " + currentDest.position);

        // Set new destination and speed
        ai.destination = currentDest.position;
        ai.speed = walkSpeed;
        ai.isStopped = false;
    }

    IEnumerator deathRoutine()
    {
 
        yield return new WaitForSeconds(jumpscareTime);
        
    }
}