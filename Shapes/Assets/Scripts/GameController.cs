﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private readonly TimeController _timeController = new TimeController();

    public bool IsInDebugMode { get; private set; } = true;

    public bool IsRunning { get; private set; } = true;

    public ScoreController ScoreController { get; private set; }

    private void Start()
    {
        _timeController.ResetTime();

        ScoreController = new ScoreController(this);
        StartCoroutine(ScoreController.GiveSurvivalBonus());
    }

    public void StopRunning() => IsRunning = false;

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

    private void DestroySpheres()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("Sphere");
        foreach (GameObject sphere in spheres)
        {
            if (sphere.GetComponent<SphereHandler>().HasSpeed())
            {
                Destroy(sphere);
            }
        }
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _timeController.TogglePause();
            }

            // Toggle IsInDebugMode Command
            if (Input.GetKeyDown(KeyCode.P))
            {
                IsInDebugMode = !IsInDebugMode;
                Debug.Log("DEBUG MODE: " + IsInDebugMode.ToString().ToUpper());
            }

            // Destroy shape GameObject Commands
            if (Input.GetKeyDown(KeyCode.C))
            {
                DestroyCubes();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                DestroyCubes();
                DestroySpheres();
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                DestroySpheres();
            }

            // Debug TimeController Commands
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _timeController.ResetTime();
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
