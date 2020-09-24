using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private GameObject _sphere;
    private GameController _gameController;
    
    private void Start()
    {
        _sphere = GameObject.FindGameObjectWithTag("Sphere");
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        StartCoroutine(EmitSpheres());
    }

    private IEnumerator EmitSpheres()
    {
        while (_gameController.IsRunning)
        {
            yield return new WaitForSeconds(3);

            if (_gameController.IsRunning)
            {
                Instantiate(_sphere, Vector3.up, Quaternion.identity);
            }
        }
    }
}
