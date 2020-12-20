using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private const float _emitterDelay = 3.0f;

    private GameObject _sphere;
    private GameController _gameController;

    private void Awake()
    {
        _sphere = GameObject.FindGameObjectWithTag("Sphere");
        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }

    private void Start()
    {
        StartCoroutine(EmitSpheres());
    }

    private IEnumerator EmitSpheres()
    {
        while (_gameController.IsRunning)
        {
            yield return new WaitForSeconds(_emitterDelay);

            if (_gameController.IsRunning)
            {
                Instantiate(_sphere, Vector3.up, Quaternion.identity);
            }
        }
    }
}
