using UnityEngine;

public class GameController : MonoBehaviour
{
    private TimeController timeController;

    private void Start()
    {
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            timeController.TogglePause();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            timeController.ResetTime();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            timeController.SlowDownTime();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            timeController.SpeedUpTime();
        }

        if (Input.GetKeyDown("-"))
        {
            timeController.SetTime(timeController.minTime);
        }

        if (Input.GetKeyDown("="))
        {
            timeController.SetTime(timeController.maxTime);
        }
    }
}
