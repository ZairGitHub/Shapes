using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController
{
    private readonly IGameController _gameController;
    private readonly TextMeshProUGUI _textScore;
    private readonly TextMeshProUGUI _textSurvivalBonus;
    private readonly TextMeshProUGUI _textCollisionBonus;
    private readonly WaitForSeconds _survivalBonusDelay = new WaitForSeconds(3.0f);

    private int _score;
    private int _survivalBonus;
    private int _collisionBonus;

    public ScoreController(IGameController gameController)
    {
        _gameController = gameController;

        _textScore = (TextMeshProUGUI)NullChecker
            .TryFind<TextMeshProUGUI>(Tags.TextScore);

        _textSurvivalBonus = (TextMeshProUGUI)NullChecker
            .TryFind<TextMeshProUGUI>(Tags.TextSurvivalBonus);

        _textCollisionBonus = (TextMeshProUGUI)NullChecker
            .TryFind<TextMeshProUGUI>(Tags.TextCollisionBonus);

        _textSurvivalBonus.color = Color.red;
        _textCollisionBonus.color = Color.magenta;
    }

    public IEnumerator GiveSurvivalBonus()
    {
        while (_gameController.IsRunning)
        {
            yield return _survivalBonusDelay;

            GiveSurvivalBonus(GameObject.FindGameObjectsWithTag(Tags.Cube).Length
                + GameObject.FindGameObjectsWithTag(Tags.Sphere).Length);
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
