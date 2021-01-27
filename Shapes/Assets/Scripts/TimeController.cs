using UnityEngine;

public class TimeController
{
    private const float _timeFactor = 0.05f;
    private const float _defaultTime = 1.0f;

    private float _savedTime = _defaultTime;

    public TimeController() => ResetTime();

    public float MinTime { get; private set; } = 0.05f;

    public float MaxTime { get; private set; } = 10.0f;

    public void ResetTime()
    {
        Time.timeScale = _defaultTime;
        _savedTime = Time.timeScale;
    }

    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == _savedTime ? 0.0f : _savedTime;
    }
    
    public void SlowDownTime()
    {
        Time.timeScale = ClampTime(Time.timeScale - _timeFactor);
        /*Time.timeScale = (Time.timeScale - _timeFactor > MinTime) ?
            Time.timeScale -= _timeFactor : MinTime;*/

        _savedTime = Time.timeScale;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = (Time.timeScale + _timeFactor < MaxTime) ?
            Time.timeScale += _timeFactor : MaxTime;

        _savedTime = Time.timeScale;
    }

    public void SetTime(float timeScale)
    {
        if (timeScale >= MinTime && timeScale <= MaxTime)
        {
            Time.timeScale = timeScale;
            _savedTime = timeScale;
        }
    }

    private float ClampTime(float timeScale)
    {
        return Mathf.Clamp(timeScale, MinTime, MaxTime);
    }
}
