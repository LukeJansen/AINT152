using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    // Define public variables
    public Transform target;
    public float speed = 5.0f;
    public Animator anim;

    // Define private variables
    private PlayerBehaviour player;

    private void Start()
    {
        // Get the animator component from the Game Object.
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // If there is a target
        if (target != null)
        {
            //Check if the player is visible
            player = target.GetComponent<PlayerBehaviour>();

            if (player.visible)
            {
                // If the agent is not too close to the player
                if (Vector3.Distance(transform.position, target.transform.position) > 1.15)
                {
                    // Reset all velocities.
                    if (GetComponent<Rigidbody2D>() != null)
                    {
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                    }

                    // Move towards the object.
                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
                    // Start walking animation.
                    anim.SetBool("Walking", true);
                }
            }
            // If player is invisible
            else
            {
                // Stop walking animation.
                anim.SetBool("Walking", false);
            }
        }
        // If there is not target
        else
        {
            // Stop walking animation.
            anim.SetBool("Walking", false);
        }

        
    }
}
