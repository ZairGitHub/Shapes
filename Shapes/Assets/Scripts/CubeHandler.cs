using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private const float _collisionScale = 1.1f;
    private const float _minSpeed = 0.1f;
    private const float _maxSpeed = 0.4f;
    private const float _speedMultiplier = 0.02f;

    private float _boundaryWrapDistance;
    private float _speed;
    private float _horizontal;
    private float _vertical;
    private IConstants _constants;
    private IGameController _gameController;
    private Vector3 _direction;
    private Rigidbody _rb;
    private ScoreController _scoreController;

    private void Awake()
    {
        BoxCollider collider = (BoxCollider)NullChecker.TryGet<BoxCollider>(
            gameObject, GetComponent<BoxCollider>());

        _boundaryWrapDistance = collider.bounds.size.x * _collisionScale;

        _rb = (Rigidbody)NullChecker.TryGet<Rigidbody>(
            gameObject, GetComponent<Rigidbody>());
    }

    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        _constants = (Constants)NullChecker.TryGet<Constants>(gameObject,
                GameObject.FindWithTag("Constants").GetComponent<Constants>());

        _gameController = (GameController)NullChecker.TryGet<GameController>(gameObject,
                GameObject.FindWithTag("GameController").GetComponent<GameController>());

        _scoreController = _gameController.ScoreController;
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
                    _rb.MovePosition(new Vector3(-_constants.BoundaryWidth + _boundaryWrapDistance,
                    _rb.position.y, _rb.position.z));
                    break;
                case "BoundarySouth":
                    _rb.MovePosition(new Vector3(_rb.position.x,
                    _constants.BoundaryHeight - _boundaryWrapDistance, _rb.position.z));
                    break;
                case "BoundaryWest":
                    _rb.MovePosition(new Vector3(_constants.BoundaryWidth - _boundaryWrapDistance,
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
