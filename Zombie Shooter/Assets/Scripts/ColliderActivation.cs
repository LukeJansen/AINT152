using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderActivation : MonoBehaviour
{

    public Sprite sprite;
    public string title;
    public string text;


    public GameObject gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (tag == "Tutorial")
            {
                gameUI.GetComponent<GameUI>().EnableTutorial(sprite, title, text, 0);
                Destroy(gameObject);

            }
            else if (tag == "LevelComplete")
            {
                gameUI.GetComponent<GameUI>().EnableTutorial(sprite, title, text, 1);
            }
        }
    }

}
