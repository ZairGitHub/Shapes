using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private readonly WaitForSeconds _survivalBonusDelay = new WaitForSeconds(3.0f);
    
    private int _score;
    private int _survivalBonus;
    private int _collisionBonus;
    private IGameController _gameController;
    private TMP_Text _textScore;
    private TMP_Text _textSurvivalBonus;
    private TMP_Text _textCollisionBonus;

    private void Start()
    {
        _gameController = (GameController)NullChecker.TryGet<GameController>(gameObject,
                GameObject.FindWithTag("GameController").GetComponent<GameController>());

        _textScore = (TMP_Text)NullChecker.TryGet<TMP_Text>(gameObject,
            GameObject.FindWithTag("TextScore").GetComponent<TMP_Text>());

        _textSurvivalBonus = (TMP_Text)NullChecker.TryGet<TMP_Text>(gameObject,
            GameObject.FindWithTag("TextSurvivalBonus").GetComponent<TMP_Text>());

        _textCollisionBonus = (TMP_Text)NullChecker.TryGet<TMP_Text>(gameObject,
            GameObject.FindWithTag("TextCollisionBonus").GetComponent<TMP_Text>());

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
