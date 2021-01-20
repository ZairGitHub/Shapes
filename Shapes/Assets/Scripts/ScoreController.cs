using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController
{
    private readonly IGameController _gameController;
    private readonly WaitForSeconds _survivalBonusDelay = new WaitForSeconds(3.0f);
    private readonly TextMeshPro _textScore;
    private readonly TextMeshPro _textSurvivalBonus;
    private readonly TextMeshPro _textCollisionBonus;

    private int _score;
    private int _survivalBonus;
    private int _collisionBonus;

    public ScoreController(IGameController gameController)
    {
        _gameController = gameController;

        try
        {
            _textScore = GameObject.FindWithTag("TextScore").GetComponent<TextMeshPro>();
        }
        catch (NullReferenceException)
        {
            _textScore = new GameObject().AddComponent<TextMeshPro>();
        }

        try
        {
            _textScore = GameObject.FindWithTag("TextScore").GetComponent<TextMeshPro>();
        }
        catch (NullReferenceException)
        {
            _textScore = new GameObject().AddComponent<TextMeshPro>();
        }

        try
        {
            _textSurvivalBonus =
                GameObject.FindWithTag("TextSurvivalBonus").GetComponent<TextMeshPro>();
        }
        catch (NullReferenceException)
        {
            _textSurvivalBonus = new GameObject().AddComponent<TextMeshPro>();
        }

        try
        {
            _textCollisionBonus =
                GameObject.FindWithTag("TextCollisionBonus").GetComponent<TextMeshPro>();
        }
        catch (NullReferenceException)
        {
            _textCollisionBonus = new GameObject().AddComponent<TextMeshPro>();
        }

        _textSurvivalBonus.color = Color.red;
        _textCollisionBonus.color = Color.magenta;
    }

    public IEnumerator GiveSurvivalBonus()
    {
        while (_gameController.IsRunning)
        {
            yield return _survivalBonusDelay;

            GiveSurvivalBonus(GameObject.FindGameObjectsWithTag("Cube").Length
                + GameObject.FindGameObjectsWithTag("Sphere").Length);
        }
    }

    public void GiveCollisionBonus()
    {
        if (_gameController.IsRunning)
        {
            AddBonusToScoreText(1);

            _collisionBonus++;
            _textCollisionBonus.text = "++" + _collisionBonus;
        }
    }

    private void GiveSurvivalBonus(int bonus)
    {
        if (_gameController.IsRunning)
        {
            AddBonusToScoreText(bonus);

            _survivalBonus += bonus;
            _textSurvivalBonus.text = "+" + _survivalBonus;
        }
    }

    private void AddBonusToScoreText(int bonus)
    {
        _score += bonus;
        _textScore.text = "Score: " + _score;   
    }
}
