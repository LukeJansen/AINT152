using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    public Transform target;
    public float speed = 5.0f;
    public Animator anim;

    private PlayerBehaviour player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {

            player = target.GetComponent<PlayerBehaviour>();

            if (player.visible)
            {
                if (Vector3.Distance(transform.position, target.transform.position) > 1.25)
                {
                    if (GetComponent<Rigidbody2D>() != null)
                    {
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                    }

                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
                    anim.SetBool("Walking", true);
                }
            }
            else
            {
                anim.SetBool("Walking", false);
            }
        }

        
    }
}
