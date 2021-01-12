using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Constants _constants;
    private GameController _gameController;
    private PlayerSpawner _playerSpawner;

    private Rigidbody _rb;
    private Vector3 _movement;

    private float _speed;

    private void Awake()
    {
        _playerSpawner = GetComponent<PlayerSpawner>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;        
        _rb.useGravity = false;

        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();

        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _speed = _constants.BoundaryWidth;
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
                DebugModeCommand();
            }
            else
            {
                _gameController.Stop();
                gameObject.SetActive(false);
            }
        }
    }

    //Convert to SetSpawnPosition() to private after removing Debug command
    private void DebugModeCommand()
    {
        _playerSpawner.SetSpawnPosition();
    }
}
