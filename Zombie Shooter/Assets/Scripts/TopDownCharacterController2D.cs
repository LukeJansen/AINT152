using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rigidBody2D;

    public Animator anim;

	void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(x, y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

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
