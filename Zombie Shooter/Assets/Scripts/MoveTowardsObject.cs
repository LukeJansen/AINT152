using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    public Transform target;
    public float speed = 5.0f;

    private PlayerBehaviour player;

    private void FixedUpdate()
    {
        if (target != null)
        {

            player = target.GetComponent<PlayerBehaviour>();

            if (player.visible)
            {

                Debug.Log("Visible");

                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                }

                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            }
        }

        
    }
}
