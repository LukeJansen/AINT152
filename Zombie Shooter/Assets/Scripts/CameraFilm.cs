using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFilm : MonoBehaviour {

    // Define public variables.
    public Transform transform;
    public Vector3 vec1, vec2;

	// Use this for initialization
	void Start () {
        // Set the starting point of the camera.
        transform.position = vec1;
	}
	
	// Update is called once per frame
	void Update () {

        // Move camera between two points
        transform.position = Vector3.Lerp(transform.position, vec2, Time.deltaTime * 0.25f);

	}
}
