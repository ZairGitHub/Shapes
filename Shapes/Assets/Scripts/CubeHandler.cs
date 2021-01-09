using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private const float _collisionScale = 1.1f;
    private const float _minSpeed = 0.1f;
    private const float _maxSpeed = 0.2f;
    private const float _speedMultiplier = 0.02f;

    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;
    private Rigidbody _rb;

    private Vector3 _direction;

    private float _speed;
    private float _boundaryWrapDistance;
    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();

        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _scoreController = GameObject.FindGameObjectWithTag("ScoreController")
            .GetComponent<ScoreController>();

        _rb = GetComponent<Rigidbody>();
        _boundaryWrapDistance =
            GetComponent<Collider>().bounds.size.x * _collisionScale;
    }

    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
    }

    public bool HasSpeed() => _speed > 0.0f;

    public void SetDirection(float x, float y)
    {
        _horizontal = x > 0.0f ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);
        _vertical = y > 0.0f ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);

        _speed = _constants.BoundaryWidth * _minSpeed;
    }

    private void RecalculateDirection()
    {
        _horizontal = Random.Range(-1.0f, 1.0f);
        _vertical = Random.Range(-1.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        if (_gameController.IsRunning)
        {
            _direction = new Vector3(_horizontal, _vertical, 0.0f).normalized;
            _rb.velocity = _direction * _speed;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Boundary"))
        {
            switch (collision.gameObject.tag)
            {
                case "BoundaryNorth":
                    _rb.MovePosition(new Vector3(_rb.position.x,
                    -_constants.BoundaryHeight + _boundaryWrapDistance, _rb.position.z));
                    break;
                case "BoundaryEast":
                    _rb.MovePosition(new Vector3(_constants.BoundaryWidth - _boundaryWrapDistance,
                    _rb.position.y, _rb.position.z));
                    break;
                case "BoundarySouth":
                    _rb.MovePosition(new Vector3(_rb.position.x,
                    _constants.BoundaryHeight - _boundaryWrapDistance, _rb.position.z));
                    break;
                case "BoundaryWest":
                    _rb.MovePosition(new Vector3(-_constants.BoundaryWidth + _boundaryWrapDistance,
                    _rb.position.y, _rb.position.z));
                    break;
            }
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            _horizontal = -_horizontal;
            _vertical = -_vertical;

            GiveCollisionBonus(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            RecalculateDirection();
            GiveCollisionBonus(collision.gameObject);
        }
    }

    private void GiveCollisionBonus(GameObject other)
    {
        if (other.GetInstanceID() > GetInstanceID())
        {
            _scoreController.GiveCollisionBonus();
        }
    }
}
