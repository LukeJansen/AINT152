using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    // Define public variables
    public Transform target;
    public float smoothing = 5.0f;
    public float mapX, mapY;

    // Define private variables
    private float minX, maxX, minY, maxY;

    private void Start()
    { 
        // Find vertical and horizontal size of screen in world position.
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calulcate the bounds of the map.
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }

    void Update () {
        // Calculate the new position based on the x and y of the target.
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        // Clamp the values to the min and max so the camera does not go off the sides of the map.
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        // Create a smooth transition to follow the target.
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.01f));
	}
}
