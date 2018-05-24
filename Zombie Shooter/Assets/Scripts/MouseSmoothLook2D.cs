using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSmoothLook2D : MonoBehaviour {

    // Define public variables
    public Camera theCamera;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

	void Update () {
        // Calulcate the mouse position as a world point.
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        
        // get difference between the target and the object
        Vector3 difference = target - transform.position;
        difference.Normalize();

        // Create rotation and smoothly transition.
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
	}
}
