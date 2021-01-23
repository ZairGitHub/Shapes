using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TMP_Text _textDebugTime;

    private void Start()
    {
        _textDebugTime = (TMP_Text)NullChecker
            .TryFind<TextMeshProUGUI>(Tags.TextDebugTime);
    }

    private void Update()
    {
        _textDebugTime.text = $"FPS: {(int)(1.0f / Time.unscaledDeltaTime):000}, Speed: x{Time.timeScale:0.00}";
    }
}
