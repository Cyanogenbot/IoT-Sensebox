using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshNPCController : MonoBehaviour
{
    private NavMeshAgent agent;
    public float range = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewRandomDestination();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            SetNewRandomDestination();
        }
    }

    private void SetNewRandomDestination()
    {
        Vector3 randomPoint = Random.insideUnitSphere * range; // Generate a random point within a range
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas)) // Find a valid position on the NavMesh
        {
            agent.SetDestination(hit.position);
        }
    }
}
