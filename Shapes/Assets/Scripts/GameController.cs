using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool IsRunning { get; private set; }

    private TimeController _timeController;
    private ScoreController _scoreController;

    // Manually set to control activation of PlayerController destruction logic
    public bool IsInDebugMode = false;

    private void Start()
    {
        IsRunning = true;

        _timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        _scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        StartCoroutine(_scoreController.GiveSurvivalBonus());
    }

    public void Reset()
    {
        IsRunning = false;
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _timeController.TogglePause();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _timeController.Reset();
            }

            else if (Input.GetKey(KeyCode.Alpha1))
            {
                _timeController.SlowDownTime();
            }

            else if (Input.GetKey(KeyCode.Alpha2))
            {
                _timeController.SpeedUpTime();
            }

            else if (Input.GetKeyDown("-"))
            {
                _timeController.SetTime(_timeController.MinTime);
            }

            else if (Input.GetKeyDown("="))
            {
                _timeController.SetTime(_timeController.MaxTime);
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
