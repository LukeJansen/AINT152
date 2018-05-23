using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit2D : MonoBehaviour {

    public int damage = 1;
    public string damageTag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("BulletIgnore")) {
            if (other.CompareTag(damageTag))
            {
                Debug.Log("Hit");
                other.SendMessage("TakeDamage", damage);
            }

            Destroy(gameObject);
        }
    }
}
