using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameController gameController;

    private TMP_Text textScore;
    private TMP_Text textSurvivalBonus;
    private TMP_Text textCollisionBonus;
    private int score;
    private int survivalBonus;
    private int collisionBonus;
    
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        textScore = GameObject.FindGameObjectWithTag("TextScore").GetComponent<TMP_Text>();
        textSurvivalBonus = GameObject.FindGameObjectWithTag("TextSurvivalBonus").GetComponent<TMP_Text>();
        textCollisionBonus = GameObject.FindGameObjectWithTag("TextCollisionBonus").GetComponent<TMP_Text>();

        textSurvivalBonus.color = Color.red;
        textCollisionBonus.color = Color.magenta;

        Reset();
    }

    public void Reset()
    {
        score = 0;
    }

    public IEnumerator GiveSurvivalBonus()
    {
        while (gameController.IsRunning())
        {
            yield return new WaitForSeconds(3);

            if (gameController.IsRunning())
            {
                GiveSurvivalBonus(GameObject.FindGameObjectsWithTag("Cube").Length + GameObject.FindGameObjectsWithTag("Sphere").Length);
            }
        }
    }

    private void GiveSurvivalBonus(int bonus)
    {
        UpdateScoreText(bonus);
        survivalBonus += bonus;
        textSurvivalBonus.text = "+" + survivalBonus;
    }

    private void UpdateScoreText(int bonus)
    {
        score += bonus;
        textScore.text = "Score: " + score;
    }

    public void GiveCollisionBonus()
    {
        UpdateScoreText(1);
        collisionBonus++;
        textCollisionBonus.text = "++" + collisionBonus;
    }
}
