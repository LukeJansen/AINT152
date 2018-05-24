using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryHandler : MonoBehaviour {

    public Text text;
    public GameManager gameManager;

	// Update is called once per frame
	void Update () {
        text.rectTransform.position= new Vector3 (text.rectTransform.position.x, text.rectTransform.position.y + 0.75f);

        if (text.rectTransform.position.y > (Screen.height + 600) || Input.GetKeyDown(KeyCode.Escape)) gameManager.LoadLevel("Main Menu");
	}


}
