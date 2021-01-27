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

    private int DisplayFPS() => (int)(1.0f / Time.unscaledDeltaTime);

    private float DisplaySpeed() => Time.timeScale;

    private void Update()
    {
        _textDebugTime.text =
            $"FPS: {DisplayFPS():000}, Speed: x{DisplaySpeed():0.00}";
    }
}
