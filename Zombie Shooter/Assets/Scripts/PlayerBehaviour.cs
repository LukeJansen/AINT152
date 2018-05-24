using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public int health = 100;
    public bool visible = true;

    public AudioSource musicAudio;
    public AudioSource audio;
    public AudioClip hitSound;

    public Light light;

    private SpriteRenderer sprite;
    private bool dying = false;
    private float time;
    
    
    private void Start()
    {
        SendHealthData();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        time = Time.time;
    }

    void Update () {
        var startVolume = musicAudio.volume;
        if (dying)
        {
            

            light.GetComponent<Light>().color = new Color(5, 0, 0);
            visible = false;
            if (Time.time - time > 0.1)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.1f);
                musicAudio.volume = sprite.color.a * startVolume;
                time = Time.time;
            }            
        }
        if (sprite.color.a <= 0)
        {
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.Death();
            musicAudio.Stop();
            musicAudio.volume = startVolume;
        }
	}

    public void TakeDamage(int damage)
    {
        if (health > 0) health -= damage;

        audio.clip = hitSound;
        audio.Play();

        SendHealthData();

        if (health <= 0) Die();
    }

    public void Heal(int healAmount)
    {
        if ((health + healAmount) <= 100)
        {
            health += healAmount;
            
        } else
        {
            health = 100;
        }

        SendHealthData();
    }

    public void SetVisibility(bool value)
    {
        visible = value;
    }
	
	void Die()
    {
        dying = true;
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
