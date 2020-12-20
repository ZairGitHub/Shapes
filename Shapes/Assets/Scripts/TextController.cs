using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TMP_Text _textDebugTime;

    private void Awake()
    {
        _textDebugTime = GameObject.FindGameObjectWithTag("TextDebugTime")
            .GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _textDebugTime.text = "Time: " + Time.timeScale.ToString("0.00");
    }
}
