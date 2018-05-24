using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFilm : MonoBehaviour {

    public Transform transform;

    public Vector3 vec1, vec2;

	// Use this for initialization
	void Start () {
        transform.position = vec1;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, vec2, Time.deltaTime * 0.25f);

	}
}
