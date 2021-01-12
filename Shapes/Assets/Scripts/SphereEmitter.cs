using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private const float _emitterDelay = 3.0f;

    private GameObject _sphere;
    private GameController _gameController;

    private void Start()
    {
        _sphere = GameObject.FindGameObjectWithTag("Sphere");
        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        StartCoroutine(EmitSpheres());
    }

    private IEnumerator EmitSpheres()
    {
        while (_gameController.IsRunning)
        {
            yield return new WaitForSeconds(_emitterDelay);

            EmitSphere();
        }
    }

    private void EmitSphere()
    {
        if (_gameController.IsRunning)
        {
            SphereHandler sphere = Instantiate(
                _sphere, Vector3.up, Quaternion.identity)
                .GetComponent<SphereHandler>();

            sphere.SetDirection();
        }
    }
}
