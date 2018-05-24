using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour {

    // Defining public variables
    public int health = 10;
    public int damage = 2;
    public float loseRange = 7.5f;
    public Transform player;
    
    // Defining private variables
    private float damageTime = 1;

    private void Update()
    {
        // If player has been detected
        if (player != null)
        {
            // Calculate distance between player and agent, if it is greater than loseRange, lost player.
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > loseRange)
            {
                UpdatePlayerVariable(null);
            }
        }
    }

    // When the player and agent have collided
    private void OnCollisionStay2D(Collision2D other)
    {
        // If it has been a second since last damage and the player is visible, damage the player.
        if ((Time.time - damageTime) >= 1)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<PlayerBehaviour>().visible)
            {
                damageTime = Time.time;
                other.gameObject.SendMessage("TakeDamage", damage);
            }
        }
    }

    private void FixedUpdate()
    {
        // Reset agent velocities
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    // Method to update all of the agent's references to player.
    public void UpdatePlayerVariable(Transform value)
    {
        player = value;
        GetComponent<MoveTowardsObject>().target = value;
        GetComponent<SmoothLookAtTarget2D>().target = value;
    }

    
}
