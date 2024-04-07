using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public Transform teleportLocationsParent; // Parent GameObject containing teleportation locations
    private Transform[] teleportLocations; // Array of teleportation locations

    private void Start()
    {
        // Get all child transforms of teleportLocationsParent
        if (teleportLocationsParent != null)
        {
            teleportLocations = new Transform[teleportLocationsParent.childCount];
            for (int i = 0; i < teleportLocationsParent.childCount; i++)
            {
                teleportLocations[i] = teleportLocationsParent.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("Teleportation locations parent is not assigned!");
        }
    }

    private void Teleport()
    {
        if (teleportLocations != null && teleportLocations.Length > 0)
        {
            int randomIndex = Random.Range(0, teleportLocations.Length);
            transform.position = teleportLocations[randomIndex].position;
        }
        else
        {
            Debug.LogError("No teleportation locations found!");
        }
    }

    // Example method to call when Nextbot needs to teleport
    public void DoTeleport()
    {
        Teleport();
    }
}