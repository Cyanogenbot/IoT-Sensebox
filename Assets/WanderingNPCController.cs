using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingNPCController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the NPC moves
    private Vector3 targetPosition; // Position to move towards
    public float obstacleAvoidanceRange = 2f; // Range to detect obstacles
    public float avoidForce = 5f; // Force applied to avoid obstacles

    private void Start()
    {
        // Set the initial target position
        SetNewRandomTarget();
    }

    private void Update()
    {
        // Move the NPC towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the NPC reaches the target position, set a new random target
        if (transform.position == targetPosition)
        {
            SetNewRandomTarget();
        }

        // Perform obstacle avoidance
        PerformObstacleAvoidance();
    }

    private void SetNewRandomTarget()
    {
        // Generate a random position within a specified range
        targetPosition = transform.position + new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
    }

    private void PerformObstacleAvoidance()
    {
        // Create a raycast in the forward direction of the NPC
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, obstacleAvoidanceRange))
        {
            // Calculate the desired direction to avoid the obstacle
            Vector3 desiredDirection = Vector3.Reflect(transform.forward, hit.normal);

            // Apply a steering force to avoid the obstacle
            transform.rotation = Quaternion.LookRotation(desiredDirection);
            transform.position += transform.forward * moveSpeed * Time.deltaTime * avoidForce;
        }
    }
}
