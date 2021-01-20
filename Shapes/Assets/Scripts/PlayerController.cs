using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private IConstants _constants;
    private IGameController _gameController;
    private IUnityService _unityService;
    private Movement _movement;
    private Rigidbody _rb;
    private PlayerSpawner _playerSpawner;

    public void RunTestingConstructor(IUnityService unityService, float speed)
    {
        _unityService = unityService;
        _speed = speed;
    }

    private void Awake()
    {
        _rb = (Rigidbody)NullChecker
            .TryGet<Rigidbody>(gameObject, GetComponent<Rigidbody>());

        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
    }

    private void Start()
    {
        try
        {
            _constants = GameObject.FindWithTag("Constants").GetComponent<Constants>();
        }
        catch (NullReferenceException)
        {
            _constants = gameObject.AddComponent<Constants>();
        }
        
        try
        {
            _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        }
        catch (NullReferenceException)
        {
            _gameController = gameObject.AddComponent<GameController>();
        }

        _speed = _constants.BoundaryWidth;
        _movement = new Movement();
        _playerSpawner = new PlayerSpawner(_constants);
        _playerSpawner.SetSpawnPosition(_rb);
        _unityService = new UnityService();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement.Move(
            _unityService.GetAxis("Horizontal"),
            _unityService.GetAxis("Vertical")) * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube")
            || collision.gameObject.CompareTag("Sphere"))
        {
            if (_gameController.IsInDebugMode)
            {
                RunDebugModeCommand();
            }
            else
            {
                _gameController.StopRunning();
                gameObject.SetActive(false);
            }
        }
    }

    //Convert to SetSpawnPosition() to private after removing Debug command
    private void RunDebugModeCommand()
    {
        _playerSpawner.SetSpawnPosition(_rb);
    }
}
