using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour {

    public GameObject Hero;

    void Start()
    {
        Hero = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
		if (transform.localScale.y < 1)
        {
            Debug.Log(transform.position);

            Vector3 move = new Vector3(0, 0.05f, 0);

            transform.Translate(move, Space.World);

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
