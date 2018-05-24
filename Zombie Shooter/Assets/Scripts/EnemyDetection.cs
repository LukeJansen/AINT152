using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    public AudioSource audio;

    private GameObject player;

	// Use this for initialization
	void Start () {
        audio = transform.parent.GetComponent<AudioSource>();
        audio.volume = (GameObject.FindWithTag("MenuController").GetComponent<MenuScreenSettings>().volume) / 2;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PlayerBehaviour>().visible)
        {
            player = collision.gameObject;
            GetComponentInParent<AgentBehaviour>().UpdatePlayerVariable(player.transform);
            audio.Play();
        }
    }
}
