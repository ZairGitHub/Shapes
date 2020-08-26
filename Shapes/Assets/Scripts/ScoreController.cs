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
    }

    public void Reset()
    {
        score = 0;
    }

    private void FixedUpdate()
    {
        if (gameController.IsRunning())
        {
            score += 1;
                //+ GameObject.FindGameObjectsWithTag("Cube").Length
                //+ GameObject.FindGameObjectsWithTag("Sphere").Length * 2;
            textScore.text = "Score: " + score;
        }
    }

    public void GrantCubeBonus()
    {
        score += 10;
    }

    public void GrantSphereBonus()
    {
        score += 30;
    }
}
