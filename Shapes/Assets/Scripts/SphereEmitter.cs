using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private readonly WaitForSeconds _emitterDelay = new WaitForSeconds(3.0f);

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
            yield return _emitterDelay;

            if (_gameController.IsRunning)
            {
                SphereHandler sphere = Instantiate(
                    _sphere, Vector3.up, Quaternion.identity)
                    .GetComponent<SphereHandler>();

                yield return null;

                sphere.SetDirection();
            }
        }
    }
}
