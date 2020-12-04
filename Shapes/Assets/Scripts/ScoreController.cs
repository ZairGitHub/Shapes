using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameController _gameController;
    private TMP_Text _textScore;
    private TMP_Text _textSurvivalBonus;
    private TMP_Text _textCollisionBonus;

    private int _score;
    private int _survivalBonus;
    private int _collisionBonus;
    
    private void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _textScore = GameObject.FindGameObjectWithTag("TextScore")
            .GetComponent<TMP_Text>();

        _textSurvivalBonus = GameObject.FindGameObjectWithTag("TextSurvivalBonus")
            .GetComponent<TMP_Text>();

        _textCollisionBonus = GameObject.FindGameObjectWithTag("TextCollisionBonus")
            .GetComponent<TMP_Text>();

        _textSurvivalBonus.color = Color.red;
        _textCollisionBonus.color = Color.magenta;
    }

    public IEnumerator GiveSurvivalBonus()
    {
        while (_gameController.IsRunning)
        {
            yield return new WaitForSeconds(3);

            GiveSurvivalBonus(GameObject.FindGameObjectsWithTag("Cube").Length
                + GameObject.FindGameObjectsWithTag("Sphere").Length);
        }
    }

    private void GiveSurvivalBonus(int bonus)
    {
        if (_gameController.IsRunning)
        {
            UpdateScoreText(bonus);
            _survivalBonus += bonus;
            _textSurvivalBonus.text = "+" + _survivalBonus;
        }
    }

    private void UpdateScoreText(int bonus)
    {
        if (_gameController.IsRunning)
        {
            _score += bonus;
            _textScore.text = "Score: " + _score;
        }
    }

    public void GiveCollisionBonus()
    {
        if (_gameController.IsRunning)
        {
            UpdateScoreText(1);
            _collisionBonus++;
            _textCollisionBonus.text = "++" + _collisionBonus;
        }
    }
}
