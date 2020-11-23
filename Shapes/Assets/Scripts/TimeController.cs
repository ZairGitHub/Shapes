using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float MinTime { get; private set; } = 0.05f;
    public float MaxTime { get; private set; } = 10.0f;

    private readonly float _timeFactor = 0.05f;

    private float _savedTime;

    private void Start() => ResetTime();

    public void ResetTime()
    {
        Time.timeScale = 1.0f;
        _savedTime = Time.timeScale;
    }

    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == _savedTime ? 0.0f : _savedTime;
    }
    
    public void SlowDownTime()
    {
        Time.timeScale = Time.timeScale - _timeFactor > MinTime ? Time.timeScale -= _timeFactor : MinTime;
        _savedTime = Time.timeScale;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = Time.timeScale + _timeFactor < MaxTime ? Time.timeScale += _timeFactor : MaxTime;
        _savedTime = Time.timeScale;
    }

    public void SetTime(float timeModifier)
    {
        Time.timeScale = timeModifier;
        _savedTime = timeModifier;
    }
}
