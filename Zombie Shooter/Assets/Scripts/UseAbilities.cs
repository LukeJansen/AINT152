using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilities : MonoBehaviour {

    public GameObject hero;
    public GameObject qPrefab;
    public Transform abilitySpawn;

    public int wHealAmount;

    private GameObject qObject;
    private SpriteRenderer sprite;
    private float eStart;
    private float eDuration;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        eDuration = 2f;
	}
	
	// Update is called once per frame
	void Update () {

        if (qObject != null)
        {
            qObject.transform.position = abilitySpawn.position;
            qObject.transform.rotation = abilitySpawn.rotation;
        }

		if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 spawnPosition = abilitySpawn.position;

            qObject = Instantiate(qPrefab, spawnPosition, abilitySpawn.rotation);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            GameObject arrow = GameObject.FindWithTag("Respawn");

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            float distance = Vector3.Distance(hero.transform.position, mousePosition);
            Vector3 unitVector = (mousePosition - hero.transform.position) / distance;

            float scale = arrow.transform.localScale.y * 6;

            hero.transform.position = hero.transform.position + (scale * unitVector);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            hero.SendMessage("Heal", wHealAmount);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 0.5f);
            hero.SendMessage("SetVisibility", false);
            eStart = Time.time;
        }

        if ((Time.time - eStart) > eDuration)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, 1f);
            hero.SendMessage("SetVisibility", false);
        }
    }
}
