using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private int health;
    private int score;
    private string gameInfo = "";

    private Rect boxRect = new Rect(10, 10, 300, 50);

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleOnUpdateHealth;
        AddScore.OnSendScore += HandleOnSendScore;
    }

    private void OnDisable ()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleOnUpdateHealth;
        AddScore.OnSendScore -= HandleOnSendScore;
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
	
	void UpdateUI () {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
	}

    private void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
