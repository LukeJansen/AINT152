using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderActivation : MonoBehaviour
{

    // Define public variables.
    public Sprite sprite;
    public string title;
    public string text;
    public GameObject gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collision is a player
        if (collision.tag == "Player")
        {
            // If collider is a tutorial zone
            if (tag == "Tutorial")
            {
                // Activate tutorial panel and destroy this collider to stop second activation
                gameUI.GetComponent<GameUI>().EnableTutorial(sprite, title, text, 0);
                Destroy(gameObject);

            }
            // If collider is a level complete zone
            else if (tag == "LevelComplete")
            {
                // Active level complete panel.
                gameUI.GetComponent<GameUI>().EnableTutorial(sprite, title, text, 1);
            }
        }
    }

}
