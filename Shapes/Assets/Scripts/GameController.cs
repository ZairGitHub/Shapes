using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private TimeController timeController;
    private ScoreController scoreController;
    private bool isRunning;

    private void Start()
    {
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
        
        isRunning = true;
        StartCoroutine(scoreController.GiveSurvivalBonus());
    }

    public void Reset()
    {
        isRunning = false;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    private void Update()
    {
        if (isRunning)
        {
            if (Input.GetButtonDown("Jump"))
            {
                timeController.TogglePause();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                timeController.Reset();
            }

            else if (Input.GetKey(KeyCode.Alpha1))
            {
                timeController.SlowDownTime();
            }

            else if (Input.GetKey(KeyCode.Alpha2))
            {
                timeController.SpeedUpTime();
            }

            else if (Input.GetKeyDown("-"))
            {
                timeController.SetTime(timeController.MinTime);
            }

            else if (Input.GetKeyDown("="))
            {
                timeController.SetTime(timeController.MaxTime);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                RestartGame();
            }
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
