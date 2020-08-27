using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float minTime;
    private float maxTime;
    
    private float savedTime;
    private float timeFactor;

    private void Start()
    {
        minTime = 0.05f;
        maxTime = 10.0f;
        timeFactor = 0.05f;

        Reset();
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        savedTime = Time.timeScale;
    }

    public float GetMinTime()
    {
        return minTime;
    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public void TogglePause()
    {
        Time.timeScale = (Time.timeScale == savedTime) ? 0.0f : savedTime;
    }

    public void SlowDownTime()
    {
        Time.timeScale = (Time.timeScale - timeFactor > minTime) ? Time.timeScale -= timeFactor : minTime;
        savedTime = Time.timeScale;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = (Time.timeScale + timeFactor < maxTime) ? Time.timeScale += timeFactor : maxTime;
        savedTime = Time.timeScale;
    }

    public void SetTime(float timeModifier)
    {
        Time.timeScale = timeModifier;
        savedTime = timeModifier;
    }
}
