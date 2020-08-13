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
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            timeController.PauseTime();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            timeController.ResumeTime();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            timeController.SlowDownTime();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            timeController.SpeedUpTime();
        }
    }
}
