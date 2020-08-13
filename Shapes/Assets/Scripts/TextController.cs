using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    TMP_Text textDebugTime;

    private void Start()
    {
        textDebugTime = GameObject.FindGameObjectWithTag("TextDebugTime").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textDebugTime.text = "Time: " + Time.timeScale.ToString("0.00");
    }
}
