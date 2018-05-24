using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        // Grow the arrow while the user holds down the button to a limit.       
        if (transform.localScale.y < 1.75)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                               transform.localScale.y + 0.01f,
                                               transform.localScale.z);
        }

        // Destroy the arrow on key up.
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Destroy(gameObject);
        }
	}
}
