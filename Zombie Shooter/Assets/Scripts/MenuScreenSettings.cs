using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenSettings : MonoBehaviour {

    // Defining public variables.
    public Slider slider;
    public GameObject panel;
    public float volume;

	// Use this for initialization
	void Start () {
        // Set starting value for volume
        volume = 1f;
        // Keep this object alive whichever scenes we switch to.
        DontDestroyOnLoad(gameObject);
	}

    // Activates the settings panel making sure the volume slider is in the right place.
    private void EnableSettings()
    {
        slider.value = volume;
        panel.SetActive(true);
    }

    // Deactivates the settings panel storing the slider value in volume.
    private void DisableSettings()
    {
        volume = slider.value;
        panel.SetActive(false);
    }

    // Quits the game.
    private void GameQuit()
    {
        Application.Quit();
    }
}
