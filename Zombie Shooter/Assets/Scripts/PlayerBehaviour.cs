using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    // Declaring Events.
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    // Declaring public variables.
    public int health = 100;
    public bool visible = true;
    public AudioSource musicAudio;
    public AudioSource audio;
    public AudioClip hitSound;
    public Light light;

    // Declaring private variables.
    private SpriteRenderer sprite;
    private bool dying = false;
    private float time;
    
    
    private void Start()
    {
        // Send health data to the UI Class.
        SendHealthData();
        // Get SpriteRenderer and AudioSource from GameObject.
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        // Get the current time and store it.
        time = Time.time;
    }

    void Update () {
        // Store the starting value of the volume.
        var startVolume = musicAudio.volume;
        // If player is dying
        if (dying)
        {
            // Set the light's colour to red.
            light.GetComponent<Light>().color = new Color(5, 0, 0);
            // Make the player not visible so they do not get attacked anymore.
            visible = false;
            // If it has been 0.1 seconds since the last colour/volume update.
            if (Time.time - time > 0.1)
            {
                // Make the sprite slowly disappear.
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.1f);
                // Make the volume slowly fade.
                musicAudio.volume = sprite.color.a * startVolume;
                // Reset time variable with current time.
                time = Time.time;
            }            
        }
        // If the player has died
        if (sprite.color.a <= 0)
        {
            // Stop the music, reset the volume and load the Game Over screen.
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            musicAudio.Stop();
            musicAudio.volume = startVolume;
            gameManager.LoadLevel("Game Over");
        }
	}

    public void TakeDamage(int damage)
    {
        // If you have health left, take damage.
        if (health > 0) health -= damage;

        // Play hit sound.
        audio.clip = hitSound;
        audio.Play();

        // Send health data to the UI script.
        SendHealthData();

        // If no health left kill the player.
        if (health <= 0) Die();
    }


    public void Heal(int healAmount)
    {
        // Heal the player making sure not to exceed health limit
        if ((health + healAmount) <= 100)
        {
            health += healAmount;
            
        } else
        {
            health = 100;
        }

        // Send health data to the UI script.
        SendHealthData();
    }

    public void SetVisibility(bool value)
    {
        //Set the visible variable to given value.
        visible = value;
    }
	
	void Die()
    {
        // Start death measures.
        dying = true;
    }

    void SendHealthData()
    {
        // Handle sending health data to UI Script.
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
