using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    // Defining public variables.
    public float speed = 5.0f;
    public Animator anim;

    // Defining private variables.
    private Rigidbody2D rigidBody2D;

    void Start () {
        // Get the RigidBody2d component from the game object.
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        // Get the input from the user.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Convert user input into a vector.
        rigidBody2D.velocity = new Vector2(x, y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

        // Control walking animation.
        if (rigidBody2D.velocity != new Vector2(0,0))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
	}
}
