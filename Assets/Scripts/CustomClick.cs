 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Events;
 
 public class CustomClick : MonoBehaviour {

    public Transform player;
    public Transform objectToTrigger;
    public UnityEvent anEvent;
    public float proximityThreshold = 2f;
    public float angleThreshold = 30f;

    private void Update()
    {
        // Check if player is close enough and facing the object
        Vector3 directionToObject = objectToTrigger.position - player.position;
        float angleToTarget = Vector3.Angle(player.forward, directionToObject);
        float distanceToTarget = Vector3.Distance(player.position, objectToTrigger.position);

        if (angleToTarget < angleThreshold && distanceToTarget < proximityThreshold)
        {
            // Check if A button is pressed on Xbox Wireless Controller
            if (Input.GetButtonDown("Jump")) // Use "Jump" instead of "Xbox_A" to directly check for "A" button
            {
                // Invoke the event
                anEvent.Invoke();
            }
        }
    }
}