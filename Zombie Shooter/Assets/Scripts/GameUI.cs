using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Image qIcon;
    public Image eIcon;
    public Image eInUse;
    public Image rIcon;

    private int health;
    private int score;
    private string gameInfo = "";

    private float qPercentage;
    private float ePercentage;
    private float eUsePercentage;
    private float rPercentage;

    private Rect boxRect = new Rect(10, 10, 300, 50);

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
        eUsePercentage = percentages[3];
        UpdateUI();
    }
	
	void UpdateUI () {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();

        qIcon.fillAmount = qPercentage;
        eIcon.fillAmount = ePercentage;
        eInUse.fillAmount = eUsePercentage;
        rIcon.fillAmount = rPercentage;
    }

    private void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
