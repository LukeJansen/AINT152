using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

    // Defining public variable.
    public AudioSource audio;

    // Defining private variable;
    private GameObject player;

	// Use this for initialization
	void Start () {
        // Get the audio source from this object and set the volume scaled down from the global volume.
        audio = transform.parent.GetComponent<AudioSource>();
        audio.volume = (GameObject.FindWithTag("MenuController").GetComponent<MenuScreenSettings>().volume) * 0.75f;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object colliding is a player and is visible, detect the player and update variables in other scripts.
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PlayerBehaviour>().visible)
        {
            player = collision.gameObject;
            GetComponentInParent<AgentBehaviour>().UpdatePlayerVariable(player.transform);
            audio.Play();
        }
    }
}
