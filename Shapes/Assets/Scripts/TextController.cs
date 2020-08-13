using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TMP_Text textDebugTime;
    private TMP_Text textDebugSavedTime;

    private void Start()
    {
        textDebugTime = GameObject.FindGameObjectWithTag("TextDebugTime").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textDebugTime.text = "Time: " + Time.timeScale.ToString("0.00");
    }
}
