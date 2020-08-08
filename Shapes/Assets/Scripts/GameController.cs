using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
    }
}
