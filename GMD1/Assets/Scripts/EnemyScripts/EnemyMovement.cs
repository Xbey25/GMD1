using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NextbotPathfinding : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Start following the player
        SetDestinationToPlayer();
    }

    private void Update()
    {
        // Keep following the player
        SetDestinationToPlayer();
    }

    private void SetDestinationToPlayer()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
