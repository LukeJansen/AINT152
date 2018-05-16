using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public int health = 100;
    public bool visible = true;

    private Animator gunAnim;

    private void Start()
    {
        SendHealthData();
    }

    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        SendHealthData();

        if (health <= 0) Die();
    }

    public void Heal(int healAmount)
    {
        if ((health + healAmount) <= 100)
        {
            health += healAmount;
            
        } else if (health + healAmount <= 100)
        {
            health += (health + healAmount) - 100;
        }

        SendHealthData();
    }

    public void SetVisibility(bool value)
    {
        visible = value;
    }
	
	void Die()
    {

    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
