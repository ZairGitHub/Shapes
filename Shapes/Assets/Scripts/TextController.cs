using System;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TMP_Text _textDebugTime;

    private void Start()
    {
        try
        {
            _textDebugTime = GameObject.FindWithTag("TextDebugTime").GetComponent<TextMeshProUGUI>();
        }
        catch (NullReferenceException)
        {
            _textDebugTime = new GameObject().AddComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        _textDebugTime.text = "Time: " + Time.timeScale.ToString("0.00");
    }
}
