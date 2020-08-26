﻿using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameController gameController;

    private TMP_Text textScore;
    private int score;
    
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        textScore = GameObject.FindGameObjectWithTag("TextScore").GetComponent<TMP_Text>();
        
        Reset();
    }

    public void Reset()
    {
        score = 0;
    }

    private void UpdateScoreText(int bonus)
    {
        textScore.text = "Score: " + (score += bonus);
    }

    public IEnumerator GiveSurvivalBonus()
    {
        while (gameController.IsRunning())
        {
            UpdateScoreText(GameObject.FindGameObjectsWithTag("Cube").Length + GameObject.FindGameObjectsWithTag("Sphere").Length);
            yield return new WaitForSeconds(3);
        }
    }

    public void GiveCubeBonus()
    {
        UpdateScoreText(10);
    }

    public void GiveSphereBonus()
    {
        UpdateScoreText(30);
    }

    public void GiveBounceBonus(string tag)
    {
        UpdateScoreText((tag.Equals("Cube")) ? 1 : 2);
    }

    public void GiveRedirectionBonus()
    {
        UpdateScoreText(1);
    }
}
