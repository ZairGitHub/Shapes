using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TMP_Text _textDebugTime;

    private void Start()
    {
        _textDebugTime = (TMP_Text)NullChecker.TryFind<TextMeshProUGUI>("TextDebugTime");
    }

    private void Update()
    {
        _textDebugTime.text = "Time: " + Time.timeScale.ToString("0.00");
    }
}
