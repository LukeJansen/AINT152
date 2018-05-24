using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioSource audio = null;

	// Use this for initialization
	void Start () {

        // Find the menuController object and grab the global volume for audio.
        var menuController = GameObject.FindWithTag("MenuController");
        if (audio != null) audio.volume = menuController.GetComponent<MenuScreenSettings>().volume;
    }

    // Method to load a scene by name.
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
