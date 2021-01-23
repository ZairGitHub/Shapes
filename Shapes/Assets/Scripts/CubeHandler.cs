using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private const float _collisionScale = 1.1f;
    private const float _minSpeed = 0.1f;
    private const float _maxSpeed = 0.4f;
    private const float _speedMultiplier = 0.02f;

    private float _boundaryWrapDistance;
    private float _horizontal;
    private float _vertical;
    private IConstants _constants;
    private IGameController _gameController;
    private Vector3 _direction;
    private Rigidbody _rb;
    private ScoreController _scoreController;

    public float Speed { get; private set; }

    private void Awake()
    {
        Collider collider = (BoxCollider)NullChecker.TryGet<BoxCollider>(gameObject);
        _boundaryWrapDistance = collider.bounds.size.x * _collisionScale;

        _rb = (Rigidbody)NullChecker.TryGet<Rigidbody>(gameObject);
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
    }

    private void Start()
    {
        _constants = (IConstants)NullChecker
            .TryFind<Constants>(Tags.Constants, gameObject);

        _gameController = (IGameController)NullChecker
            .TryFind<GameController>(Tags.GameController, gameObject);

        _scoreController = _gameController.ScoreController;
    }

    public void RunTestingConstructor(IConstants constants)
    {
        _constants = constants;
    }

    public void SetDirection(float x, float y)
    {
        _horizontal = x;
        _vertical = y;
        Speed = _constants.BoundaryWidth * _minSpeed;
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
            _rb.velocity = _direction * Speed;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains(Tags.Boundary))
        {
            switch (collision.gameObject.tag)
            {
                case nameof(Tags.BoundaryNorth):
                    _rb.MovePosition(new Vector3(_rb.position.x,
                    -_constants.BoundaryHeight + _boundaryWrapDistance, _rb.position.z));
                    break;
                case nameof(Tags.BoundaryEast):
                    _rb.MovePosition(new Vector3(-_constants.BoundaryWidth + _boundaryWrapDistance,
                    _rb.position.y, _rb.position.z));
                    break;
                case nameof(Tags.BoundarySouth):
                    _rb.MovePosition(new Vector3(_rb.position.x,
                    _constants.BoundaryHeight - _boundaryWrapDistance, _rb.position.z));
                    break;
                case nameof(Tags.BoundaryWest):
                    _rb.MovePosition(new Vector3(_constants.BoundaryWidth - _boundaryWrapDistance,
                    _rb.position.y, _rb.position.z));
                    break;
            }
        }

        if (collision.gameObject.CompareTag(Tags.Cube))
        {
            _horizontal = -_horizontal;
            _vertical = -_vertical;

            GiveCollisionBonus(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Sphere))
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
