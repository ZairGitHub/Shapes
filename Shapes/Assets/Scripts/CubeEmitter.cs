using System;
using System.Collections;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private const float _collisionScale = 2.0f;

    private readonly Color _defaultColor = Color.yellow;
    private readonly Color _emissionColor = Color.blue;
    private readonly WaitForSeconds _emitterDelay = new WaitForSeconds(1.0f);

    private float _offset;
    private IConstants _constants;
    private IGameController _gameController;
    private GameObject _cube;
    private GameObject[] _cubeEmitters;
    private EmitterProperties _emitterProperties;

    private void Start()
    {
        _constants = (IConstants)NullChecker
            .TryFind<Constants>("Constants", gameObject);

        _gameController = (IGameController)NullChecker
            .TryFind<GameController>("GameController", gameObject);

        _cube = GameObject.FindWithTag("Cube");
        if (_cube == null)
        {
            _cube = new GameObject();
            _cube.AddComponent<CubeHandler>();
        }

        _offset = _cube.GetComponent<Collider>().bounds.size.x * _collisionScale;
        _cubeEmitters = NullChecker.TryGet(GameObject.FindGameObjectsWithTag("CubeEmitter"));
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
            int RNG = UnityEngine.Random.Range(0, _cubeEmitters.Length);
            _cubeEmitters[RNG].GetComponent<Renderer>().material.color = _emissionColor;
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

                _cubeEmitters[RNG].GetComponent<Renderer>().material.color = _defaultColor;
            }
        }
    }
}
