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

        savedTime = Time.deltaTime;
        timeFactor = 0.05f;
    }

    public float getMinTime()
    {
        return minTime;
    }

    public float getMaxTime()
    {
        return maxTime;
    }

    public void TogglePause()
    {
        Time.timeScale = (Time.timeScale == savedTime) ? 0.0f : savedTime;
    }

    public void ResetTime()
    {
        Time.timeScale = 1.0f;
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
