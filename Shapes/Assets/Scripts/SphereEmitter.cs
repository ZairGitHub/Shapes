using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private GameObject sphere;
    private GameController gameController;
    
    private void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("Sphere");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(EmitSpheres());
    }

    private IEnumerator EmitSpheres()
    {
        while (gameController.IsRunning)
        {
            yield return new WaitForSeconds(3);

            if (gameController.IsRunning)
            {
                Instantiate(sphere, Vector3.up, Quaternion.identity);
            }
        }
    }
}
