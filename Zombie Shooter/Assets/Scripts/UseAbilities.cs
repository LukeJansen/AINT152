using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilities : MonoBehaviour {

    public GameObject hero;
    public GameObject healParticles;
    public GameObject qPrefab;
    public Transform abilitySpawn;

    public int wHealAmount;
    public int[] cooldowns = new int[3];

    public delegate void SendPercentage(float[] percentages);
    public static event SendPercentage OnSendPercentages;

    private GameObject qObject;
    private SpriteRenderer sprite;
    private float eStart;
    private float eDuration;
    private bool eUsed = false;
    private bool[] usability = new bool[3];
    private float[] usedTime = new float[3];
    private float[] percentages = new float[4];
    

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        eDuration = 5f;
        for (int i = 0; i < usability.Length; i++) usability[i] = true;
	}
	
	// Update is called once per frame
	void Update () {

        CooldownManager();

        if (qObject != null)
        {
            qObject.transform.position = abilitySpawn.position;
            qObject.transform.rotation = abilitySpawn.rotation;
        }

		if (Input.GetKeyDown(KeyCode.Q) && usability[0])
        {
            Vector3 spawnPosition = abilitySpawn.position;

            qObject = Instantiate(qPrefab, spawnPosition, abilitySpawn.rotation);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            GameObject arrow = GameObject.FindWithTag("Respawn");

            if (arrow != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                float distance = Vector3.Distance(hero.transform.position, mousePosition);
                Vector3 unitVector = (mousePosition - hero.transform.position) / distance;

                float scale = arrow.transform.localScale.y * 6;

                hero.transform.position = hero.transform.position + (scale * unitVector);

                usedTime[0] = Time.time;
                usability[0] = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && usability[1] && eUsed == false)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 0.5f);
            hero.SendMessage("SetVisibility", false);

            eStart = Time.time;
            eUsed = true;
        }

        if ((Time.time - eStart) > eDuration && eUsed)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 1f);
            hero.SendMessage("SetVisibility", true);
            eUsed = false;

            usedTime[1] = Time.time;
            usability[1] = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && usability[2])
        {
            hero.SendMessage("Heal", wHealAmount);
            Instantiate(healParticles, hero.transform);

            usedTime[2] = Time.time;
            usability[2] = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private void CooldownManager()
    {
        for (int i = 0; i < 3; i++)
        {
            if (((Time.time - usedTime[i]) / cooldowns[i]) <= 1 && usability[i] == false)
            {
                percentages[i] = 1 - ((Time.time - usedTime[i]) / cooldowns[i]);
            }
            else
            {
                percentages[i] = 0;
            }

            if (Time.time - eStart < eDuration && eUsed)
            {
                percentages[3] = 1 - ((Time.time - eStart) / eDuration);
            }
            else
            {
                percentages[3] = 0;
            }

            if (Time.time - usedTime[i] > cooldowns[i] && usability[i] == false)
            {
                usability[i] = true;
            }
        }

        DoSendPercentages();
    }

    public void DoSendPercentages()
    {
        if (OnSendPercentages != null)
        {
            OnSendPercentages(percentages);
        }
    }
}

