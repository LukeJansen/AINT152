using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    // Defining public variables
    public Image qIcon;
    public Image eIcon;
    public Image eInUse;
    public Image rIcon;
    public Slider healthBar;
    public GameObject tutorialPanel;
    public Text tutorialTitle;
    public Text tutorialText;
    public Image tutorialImage;
    public GameObject tutorialButton;
    public GameObject levelButton;

    // Defining private variables
    private int health;
    private int score;
    private float qPercentage;
    private float ePercentage;
    private float eUsePercentage;
    private float rPercentage;

    private void OnEnable()
    {
        // Activate event listeners
        PlayerBehaviour.OnUpdateHealth += HandleOnUpdateHealth;
        UseAbilities.OnSendPercentages += HandleOnUpdatePercentage;
    }

    private void OnDisable ()
    {
        // Deactivate event listeners
        PlayerBehaviour.OnUpdateHealth -= HandleOnUpdateHealth;
        UseAbilities.OnSendPercentages -= HandleOnUpdatePercentage;
    }

    void Start () {
        // Call UpdateUI to make sure all starting information is correct.
        UpdateUI();        
	}

    void HandleOnUpdateHealth( int newHealth)
    {
        // Update the health variable and then update the UI.
        health = newHealth;
        UpdateUI();
    }

    void HandleOnUpdatePercentage(float[] percentages)
    {
        // Update each percentage variable and then update the UI.
        qPercentage = percentages[0];
        ePercentage = percentages[1];
        rPercentage = percentages[2];
        eUsePercentage = percentages[3];
        UpdateUI();
    }
	
	void UpdateUI () {
        // Update health bar value.
        healthBar.value = health;

        // Update each cooldown/inuse images fill amount.
        qIcon.fillAmount = qPercentage;
        eIcon.fillAmount = ePercentage;
        eInUse.fillAmount = eUsePercentage;
        rIcon.fillAmount = rPercentage;
    }

    public void LoadLevel(string name)
    {
        // Restart the game and load level with given name.
        Time.timeScale = 1;
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().LoadLevel(name);
    }

    public void EnableTutorial(Sprite sprite, string title, string text, int buttonOption)
    {
        // Pause the game, Enable the tutorial panel with the given information and activate the correct button.
        Time.timeScale = 0;
        tutorialTitle.text = title;
        tutorialText.text = text;
        tutorialImage.sprite = sprite;
        tutorialPanel.SetActive(true);

        if (buttonOption == 0) tutorialButton.SetActive(true);
        if (buttonOption == 1) levelButton.SetActive(true);
    }

    public void DismissTutorial()
    {
        // Restart the game and dismiss the tutorial panel and all buttons.
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
        tutorialButton.SetActive(false);
        levelButton.SetActive(false);
    }
}
