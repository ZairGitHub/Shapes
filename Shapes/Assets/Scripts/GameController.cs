using UnityEngine;

public class GameController : MonoBehaviour
{
    private TimeController timeController;
    private bool isRunning;

    private void Start()
    {
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        isRunning = true;
    }

    public void Reset()
    {
        isRunning = false;
        timeController.Reset();
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
                timeController.ResetTime();
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
                timeController.SetTime(timeController.GetMinTime());
            }

            else if (Input.GetKeyDown("="))
            {
                timeController.SetTime(timeController.GetMaxTime());
            }
        }
    }
}
