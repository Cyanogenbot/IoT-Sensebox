using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProximityLightController : MonoBehaviour
{
    public float activationDistance = 5f; // Distance at which the light is activated

    public Light lightSource;

    private void Start()
    {
        lightSource.enabled = false; // Disable the light initially
    }

    private void Update()
    {
        // Check if the player or any NPCs are within the activation distance
         bool isPlayerInRange = IsObjectInRange(GameObject.FindGameObjectWithTag("Player").transform, lightSource.transform.position);

        bool areNPCsInRange = AreNPCsInRange();

        // Enable or disable the light based on the proximity of the player or NPCs
        lightSource.enabled = isPlayerInRange || areNPCsInRange;
    }

    private bool IsObjectInRange(Transform target, Vector3 referencePosition)
    {
        float distance = Vector3.Distance(referencePosition, target.position);
        return distance <= activationDistance;
    }

    private bool AreNPCsInRange()
    {
        NavMeshNPCController[] npcs = FindObjectsOfType<NavMeshNPCController>();
        foreach (NavMeshNPCController npc in npcs)
        {
            if (IsObjectInRange(npc.transform, transform.position))
            {
                return true;
            }
        }
        return false;
    }
}
