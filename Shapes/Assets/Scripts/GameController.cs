using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private ScoreController _scoreController;
    private TimeController _timeController;

    public bool IsInDebugMode { get; private set; } = true;
    public bool IsRunning { get; private set; } = true;

    private void Awake()
    {
        _scoreController = GameObject.FindGameObjectWithTag("ScoreController")
            .GetComponent<ScoreController>();

        _timeController = GameObject.FindGameObjectWithTag("TimeController")
            .GetComponent<TimeController>();
    }

    private void Start()
    {
        StartCoroutine(_scoreController.GiveSurvivalBonus());
    }

    public void Reset() => IsRunning = false;

    private void DestroyCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject cube in cubes)
        {
            if (cube.GetComponent<CubeHandler>().HasSpeed())
            {
                Destroy(cube);
            }
        }
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                DestroyCubes();
            }

            if (Input.GetButtonDown("Jump"))
            {
                _timeController.TogglePause();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                IsInDebugMode = !IsInDebugMode;
                Debug.Log("DEBUG MODE: " + IsInDebugMode.ToString().ToUpper());
            }

            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _timeController.ResetTime();
            }

            else if (Input.GetKeyDown("-"))
            {
                _timeController.SetTime(_timeController.MinTime);
            }

            else if (Input.GetKeyDown("="))
            {
                _timeController.SetTime(_timeController.MaxTime);
            }

            else if (Input.GetKey(KeyCode.Alpha1))
            {
                _timeController.SlowDownTime();
            }

            else if (Input.GetKey(KeyCode.Alpha2))
            {
                _timeController.SpeedUpTime();
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
