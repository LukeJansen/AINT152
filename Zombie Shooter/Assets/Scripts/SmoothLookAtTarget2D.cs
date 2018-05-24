using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtTarget2D : MonoBehaviour {

    // Defining public variables
    public Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

    // Defining private variables
    private PlayerBehaviour player;

	void Update () {
        // If the agent has a target to look at
		if (target != null)
        {
            player = target.GetComponent<PlayerBehaviour>();

            //If the player is visible
            if (player.visible)
            {
                // Calculate the angle of rotation needed to look at target.
                Vector3 difference = target.position - transform.position;
                difference.Normalize();

                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));

                // Create a smooth transition using linear interpolation to look at the target.
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
            }
        }

	}
}
