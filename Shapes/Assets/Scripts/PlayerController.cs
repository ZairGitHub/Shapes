using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Constants _constants;
    private GameController _gameController;

    private Rigidbody _rb;
    private Vector3 _movement;

    private Vector3 _topLeftSpawn;
    private Vector3 _topRightSpawn;
    private Vector3 _bottomLeftSpawn;
    private Vector3 _bottomRightSpawn;

    private float _speed;

    private void Awake()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();

        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;        
        _rb.useGravity = false;

        // Move spawn logic to a new script
        float spawnWidth = _constants.BoundaryWidth / 2.0f;
        float spawnHeight = _constants.BoundaryHeight / 2.0f;

        // Different spawn positions for different players
        _topLeftSpawn = new Vector3(-spawnWidth, spawnHeight, 0.0f);
        _topRightSpawn = new Vector3(spawnWidth, spawnHeight, 0.0f);
        _bottomLeftSpawn = new Vector3(-spawnWidth, -spawnHeight, 0.0f);
        _bottomRightSpawn = new Vector3(spawnWidth, -spawnHeight, 0.0f);

        SetSpawnPosition();
        _speed = _constants.BoundaryWidth;
    }

    private void SetSpawnPosition()
    {
        // Currently randomised until multiplayer is implemented
        int RNG = Random.Range(1, 5);
        switch (RNG)
        {
            case 1:
                _rb.MovePosition(_topLeftSpawn);
                break;
            case 2:
                _rb.MovePosition(_topRightSpawn);
                break;
            case 3:
                _rb.MovePosition(_bottomLeftSpawn);
                break;
            case 4:
                _rb.MovePosition(_bottomRightSpawn);
                break;
        }
        _rb.velocity = Vector3.zero;
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
                Debug();
            }
            else
            {
                _gameController.Reset();
                gameObject.SetActive(false);
            }
        }
    }

    private void Debug()
    {
        SetSpawnPosition();
    }
}
