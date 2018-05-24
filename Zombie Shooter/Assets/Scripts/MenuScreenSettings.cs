using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenSettings : MonoBehaviour {

    public Slider slider;
    public GameObject panel;

    public float volume;

	// Use this for initialization
	void Start () {
        volume = 1f;
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void EnableSettings()
    {
        slider.value = volume;
        panel.SetActive(true);
    }

    private void DisableSettings()
    {
        volume = slider.value;
        panel.SetActive(false);
    }

    private void GameQuit()
    {
        Application.Quit();
    }
}
