using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour {

    public int health = 10;
    public int damage = 2;
    public float loseRange = 7.5f;

    public Transform player;

    private float damageTime = 1;

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > loseRange)
            {
                UpdatePlayerVariable(null);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
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
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    public void UpdatePlayerVariable(Transform value)
    {
        player = value;
        GetComponent<MoveTowardsObject>().target = value;
        GetComponent<SmoothLookAtTarget2D>().target = value;
    }

    
}
