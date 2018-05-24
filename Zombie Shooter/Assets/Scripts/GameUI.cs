using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

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

    private int health;
    private int score;

    private float qPercentage;
    private float ePercentage;
    private float eUsePercentage;
    private float rPercentage;

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleOnUpdateHealth;
        UseAbilities.OnSendPercentages += HandleOnUpdatePercentage;
    }

    private void OnDisable ()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleOnUpdateHealth;
        UseAbilities.OnSendPercentages -= HandleOnUpdatePercentage;
    }

    void Start () {
        UpdateUI();        
	}

    void HandleOnUpdateHealth( int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void HandleOnSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }

    void HandleOnUpdatePercentage(float[] percentages)
    {
        qPercentage = percentages[0];
        ePercentage = percentages[1];
        rPercentage = percentages[2];
        eUsePercentage = percentages[3];
        UpdateUI();
    }
	
	void UpdateUI () {
        healthBar.value = health;

        qIcon.fillAmount = qPercentage;
        eIcon.fillAmount = ePercentage;
        eInUse.fillAmount = eUsePercentage;
        rIcon.fillAmount = rPercentage;
    }

    public void LoadLevel(string name)
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().LoadLevel(name);
    }

    public void EnableTutorial(Sprite sprite, string title, string text, int buttonOption)
    {
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
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
        tutorialButton.SetActive(false);
        levelButton.SetActive(false);
    }
}
