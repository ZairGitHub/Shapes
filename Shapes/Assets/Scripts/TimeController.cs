using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float MinTime { private set; get; }
    public float MaxTime { private set; get; }
    
    private float _timeFactor;
    private float _savedTime;

    private void Start()
    {
        MinTime = 0.05f;
        MaxTime = 10.0f;

        _timeFactor = 0.05f;

        Reset();
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        _savedTime = Time.timeScale;
    }

    public void TogglePause()
    {
        Time.timeScale = (Time.timeScale == _savedTime) ? 0.0f : _savedTime;
    }

    public void SlowDownTime()
    {
        Time.timeScale = (Time.timeScale - _timeFactor > MinTime) ? Time.timeScale -= _timeFactor : MinTime;
        _savedTime = Time.timeScale;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = (Time.timeScale + _timeFactor < MaxTime) ? Time.timeScale += _timeFactor : MaxTime;
        _savedTime = Time.timeScale;
    }

    public void SetTime(float timeModifier)
    {
        Time.timeScale = timeModifier;
        _savedTime = timeModifier;
    }
}
