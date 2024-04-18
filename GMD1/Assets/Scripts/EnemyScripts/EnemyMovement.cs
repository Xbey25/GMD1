using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the enemy to roam between
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            SetDestinationToWaypoint();
        }
    }

    void Update()
    {
        // Check if the agent has reached the current waypoint
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            SetDestinationToWaypoint();
        }
    }

    void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
