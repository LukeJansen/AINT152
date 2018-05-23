using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PlayerBehaviour>().visible)
        {
            player = collision.gameObject;
            GetComponentInParent<ZombieBehaviour>().UpdatePlayerVariable(player.transform);
        }
    }
}
