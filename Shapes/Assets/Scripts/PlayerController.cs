using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public for testing, otherwise private
    public float Speed;

    private Constants _constants;
    private GameController _gameController;

    private Rigidbody _rb;
    private Vector3 _movement;

    private float _spawnHeight;
    private float _spawnWidth;

    private Vector3 _topLeftSpawn;
    private Vector3 _topRightSpawn;
    private Vector3 _bottomLeftSpawn;
    private Vector3 _bottomRightSpawn;

    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        _spawnWidth = _constants.BoundaryWidth / 2;
        _spawnHeight = _constants.BoundaryHeight / 2;

        // Different spawn positions for different players
        _topLeftSpawn = new Vector3(-_spawnWidth, _spawnHeight, 0.0f);
        _topRightSpawn = new Vector3(_spawnWidth, _spawnHeight, 0.0f);
        _bottomLeftSpawn = new Vector3(-_spawnWidth, -_spawnHeight, 0.0f);
        _bottomRightSpawn = new Vector3(_spawnWidth, -_spawnHeight, 0.0f);

        Reset();
        Speed = _constants.BoundaryWidth;
    }

    private void Reset()
    {
        gameObject.SetActive(true);
        _rb.velocity = Vector3.zero;
        SetSpawnPosition();
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
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        _movement = new Vector3(horizontalAxis, verticalAxis, 0.0f);
        _rb.velocity = _movement * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Sphere"))
        {
            if (_gameController.IsInDebugMode)
            {
                Reset();
            }
            else
            {
                _gameController.Reset();
                gameObject.SetActive(false);
            }
        }
    }
}
