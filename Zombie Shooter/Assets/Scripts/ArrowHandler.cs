using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour {

    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (transform.localScale.y < 1.75)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                               transform.localScale.y + 0.01f,
                                               transform.localScale.z);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            Destroy(gameObject);
        }
	}
}
