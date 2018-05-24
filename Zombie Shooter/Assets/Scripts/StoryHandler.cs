using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryHandler : MonoBehaviour {

    // Define public variables.
    public Text text;
    public GameManager gameManager;

	// Update is called once per frame
	void Update () {
        // Make the text slowly scroll up.
        text.rectTransform.position= new Vector3 (text.rectTransform.position.x, text.rectTransform.position.y + 0.75f);

        // Once all of the text has reached the top of the screen or someone presses Escape, go to main menu.
        if (text.rectTransform.position.y > (Screen.height + 600) || Input.GetKeyDown(KeyCode.Escape)) gameManager.LoadLevel("Main Menu");
	}


}
