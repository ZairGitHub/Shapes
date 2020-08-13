using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float timeFactor;

    private void Start()
    {
        timeFactor = 0.05f;
    }

    public void TogglePause()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public void SlowDownTime()
    {
        Time.timeScale = (Time.timeScale - timeFactor > 0) ? Time.timeScale -= timeFactor : 0;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = (Time.timeScale + timeFactor < 10) ? Time.timeScale += timeFactor : 10;
    }

    public void SetTime(float timeModifier)
    {
        Time.timeScale = timeModifier;
    }
}
