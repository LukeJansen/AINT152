using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothing = 5.0f;
    private float mapX, mapY;
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        mapX = 48;
        mapY = 27;

        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }

    void Update () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.01f));
	}
}
