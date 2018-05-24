using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilities : MonoBehaviour {

    // Define public variables.
    public GameObject hero;
    public GameObject healParticles;
    public GameObject qPrefab;
    public Transform abilitySpawn;
    public int wHealAmount;
    public float eDuration;
    public int[] cooldowns = new int[3];
    public AudioClip qSound;
    public AudioClip eSound;
    public AudioClip eFinishSound;
    public AudioClip rSound;

    // Define event.
    public delegate void SendPercentage(float[] percentages);
    public static event SendPercentage OnSendPercentages;

    // Define private variables.
    private AudioSource audio;
    private GameObject qObject;
    private SpriteRenderer sprite;
    private Light spot;
    private float eStart;
    private bool eUsed = false;
    private bool[] usability = new bool[3];
    private float[] usedTime = new float[3];
    private float[] percentages = new float[4];
    

    // Use this for initialization
    void Start () {
        // Get the AudioSource, SpriteRenderer and LightComponents from the game object.
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        spot = transform.GetChild(1).GetComponent<Light>();

        // Set all of the usabilities to true.
        for (int i = 0; i < usability.Length; i++) usability[i] = true;
	}
	
	// Update is called once per frame
	void Update () {

        // Call CooldownManager.
        CooldownManager();

        // If the qObject exists
        if (qObject != null)
        {
            // Update the qObjects transform to match the player.
            qObject.transform.position = abilitySpawn.position;
            qObject.transform.rotation = abilitySpawn.rotation;
        }

        // If the Q key is down and the ability can be used
		if (Input.GetKeyDown(KeyCode.Q) && usability[0])
        {
            // Spawn the qObject infront of the player.
            Vector3 spawnPosition = abilitySpawn.position;

            qObject = Instantiate(qPrefab, spawnPosition, abilitySpawn.rotation);
        }

        // If the Q key have been lifted
        if (Input.GetKeyUp(KeyCode.Q))
        {
            // Get a reference to the current arrow
            GameObject arrow = GameObject.FindWithTag("Arrow");

            // If arrow exists
            if (arrow != null)
            {
                // Calculate mouse position in world point.
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the unit vector between player and arrow.
                float distance = Vector3.Distance(hero.transform.position, mousePosition);
                Vector3 unitVector = (mousePosition - hero.transform.position) / distance;

                // Calculate the scale to be added to the unit vector based on size of arrow.
                float scale = arrow.transform.localScale.y * 4f;

                // Teleport the player to new position.
                hero.transform.position = hero.transform.position + (scale * unitVector);

                // Play sound effects.
                audio.clip = qSound;
                audio.Play();

                // Start cooldown and disable ability.
                usedTime[0] = Time.time;
                usability[0] = false;
            }
        }

        // If the E key is down and this ability can be used.
        if (Input.GetKeyDown(KeyCode.E) && usability[1] && eUsed == false)
        {
            // Make the sprites opacity 50%, half the spot intensity and set the player as invisible.
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 0.5f);
            spot.intensity = 10;
            hero.SendMessage("SetVisibility", false);

            // Play sound effect.
            audio.clip = eSound;
            audio.Play();

            // Start in use countdown.
            eStart = Time.time;
            eUsed = true;
        }

        // If the duration of E abiliy has run out.
        if ((Time.time - eStart) > eDuration && eUsed)
        {
            // Reset all variables.
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 1f);
            spot.intensity = 20;
            hero.SendMessage("SetVisibility", true);
            eUsed = false;

            // Play sound effect.
            audio.clip = eFinishSound;
            audio.Play();

            // Start cooldown and disable ability.
            usedTime[1] = Time.time;
            usability[1] = false;
        }

        // If the R key is pressed and this ability can be used.
        if (Input.GetKeyDown(KeyCode.R) && usability[2])
        {
            // Heal the player a certain amount and spawn particles at their location.
            hero.SendMessage("Heal", wHealAmount);
            Instantiate(healParticles, hero.transform);

            // Play sound effect.
            audio.clip = rSound;
            audio.Play();

            // Start cooldown and disable ability.
            usedTime[2] = Time.time;
            usability[2] = false;
        }

        // If Escape key is down exit to main menu.
        if (Input.GetKeyDown(KeyCode.Escape)) GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().LoadLevel("Main Menu");
    }

    private void CooldownManager()
    {
        // Loop through all 3 abilities.
        for (int i = 0; i < 3; i++)
        {
            // If the ability is still on cooldown, work out the percentage and store it in the array. Otherwise set to 0%.
            if (((Time.time - usedTime[i]) / cooldowns[i]) <= 1 && usability[i] == false)
            {
                percentages[i] = 1 - ((Time.time - usedTime[i]) / cooldowns[i]);
            }
            else
            {
                percentages[i] = 0;
            }

            // If the e ability is in use, work out the percentage left and store it in the array. Otherwise set to 0%.
            if (Time.time - eStart < eDuration && eUsed)
            {
                percentages[3] = 1 - ((Time.time - eStart) / eDuration);
            }
            else
            {
                percentages[3] = 0;
            }

            // If the ability is no longer on cooldown, enable it.
            if (Time.time - usedTime[i] > cooldowns[i] && usability[i] == false)
            {
                usability[i] = true;
            }
        }

        // Send percentages to UI script.
        DoSendPercentages();
    }

    // Handle sending percentages to UI script.
    public void DoSendPercentages()
    {
        if (OnSendPercentages != null)
        {
            OnSendPercentages(percentages);
        }
    }
}

