using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;

    private IConstants _constants;
    private IGameController _gameController;

    private Vector3 _movement;

    private Rigidbody _rb;
    private PlayerSpawner _playerSpawner;

    private void Awake()
    {
        _rb = (Rigidbody)NullChecker
            .TryGet<Rigidbody>(gameObject, GetComponent<Rigidbody>());
    }

    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;        
        _rb.useGravity = false;

        _constants = (Constants)NullChecker.TryGet<Constants>(
            gameObject,
                GameObject.FindWithTag("Constants").GetComponent<Constants>());

        _gameController = (GameController)NullChecker.TryGet<GameController>(
                gameObject,
                    GameObject.FindWithTag("GameController").GetComponent<GameController>());

        _speed = _constants.BoundaryWidth;

        _playerSpawner = new PlayerSpawner(_constants);
        _playerSpawner.SetSpawnPosition(_rb);
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        _movement = new Vector3(horizontalAxis, verticalAxis, 0.0f);
        _rb.velocity = _movement * _speed;
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
