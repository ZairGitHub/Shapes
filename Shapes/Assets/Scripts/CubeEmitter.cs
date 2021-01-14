using System.Collections;
using System.Linq;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private const float _collisionScale = 2.0f;

    private readonly WaitForSeconds _emitterDelay = new WaitForSeconds(1.0f);

    private float _offset;

    private IConstants _constants;

    private GameObject _cube;
    private GameObject[] _cubeEmitters;
    private GameController _gameController;
    private EmitterProperties _emitterProperties;

    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();
        
        _cube = GameObject.FindGameObjectWithTag("Cube");
        _cubeEmitters = GameObject.FindGameObjectsWithTag("CubeEmitter")
            .OrderBy(g => g.name).ToArray();

        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _offset = _cube.GetComponent<Collider>().bounds.size.x * _collisionScale;

        _emitterProperties = new EmitterProperties(_constants, _offset);

        SetEmitterPositions();

        StartCoroutine(EmitCubes());
    }

    private void SetEmitterPositions()
    {
        foreach (GameObject cubeEmitter in _cubeEmitters)
        {
            cubeEmitter.transform.position =
                _emitterProperties.SetPosition(cubeEmitter.transform.position);
        }
    }

    private IEnumerator EmitCubes()
    {
        while (_gameController.IsRunning)
        {
            int RNG = Random.Range(0, _cubeEmitters.Length);
            _cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.blue;

            yield return _emitterDelay;

            if (_gameController.IsRunning)
            {
                Vector3 position = _cubeEmitters[RNG].transform.position;
                CubeHandler cube = Instantiate(
                    _cube, position, Quaternion.identity)
                    .GetComponent<CubeHandler>();

                yield return null;

                cube.SetDirection(
                    _emitterProperties.GetDirection(position.x),
                    _emitterProperties.GetDirection(position.y));

                _cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }
}
