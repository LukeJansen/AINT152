using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioSource audio = null;

	// Use this for initialization
	void Start () {
        var menuController = GameObject.FindWithTag("MenuController");
        if (audio != null) audio.volume = menuController.GetComponent<MenuScreenSettings>().volume;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha2)) LoadLevel("Level 2");
	}

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Death()
    {
        SceneManager.LoadScene("Game Over");
    }
}
