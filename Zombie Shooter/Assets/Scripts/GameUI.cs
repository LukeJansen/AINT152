using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Image qIcon;
    public Image eIcon;
    public Image rIcon;

    private int health;
    private int score;
    private string gameInfo = "";

    private float qPercentage;
    private float ePercentage;
    private float rPercentage;

    private Rect boxRect = new Rect(10, 10, 300, 50);

    private Rect qAbilityBox = new Rect((Screen.width / 2) - 170, (Screen.height) - 150, 100, 100);
    private Rect eAbilityBox = new Rect((Screen.width / 2) - 50, (Screen.height) - 150, 100, 100);
    private Rect rAbilityBox = new Rect((Screen.width / 2) + 70, (Screen.height) - 150, 100, 100);

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleOnUpdateHealth;
        AddScore.OnSendScore += HandleOnSendScore;
        UseAbilities.OnSendPercentages += HandleOnUpdatePercentage;
    }

    private void OnDisable ()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleOnUpdateHealth;
        AddScore.OnSendScore -= HandleOnSendScore;
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
        UpdateUI();
    }
	
	void UpdateUI () {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();

        qIcon.fillAmount = qPercentage;
        eIcon.fillAmount = ePercentage;
        rIcon.fillAmount = rPercentage;
    }

    private void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
