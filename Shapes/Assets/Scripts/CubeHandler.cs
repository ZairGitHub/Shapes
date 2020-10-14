using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;

    private Rigidbody _rb;
    private Vector3 _direction;

    private float _speed;
    private float _boundaryWrapDistance;

    private float _horizontal;
    private float _vertical;
    
    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        _speed = _constants.BoundaryWidth / 4.0f;
        _boundaryWrapDistance = GetComponent<Collider>().bounds.size.x * 1.1f;
    }

    public void SetDirection(float x, float y)
    {
        _horizontal = (x > 0.0f) ? Random.Range(0.0f, _constants.PositiveDirection) : Random.Range(_constants.NegativeDirection, 0.0f);
        _vertical = (y > 0.0f) ? Random.Range(0.0f, _constants.PositiveDirection) : Random.Range(_constants.NegativeDirection, 0.0f);
    }

    private void RecalculateDirection()
    {
        _horizontal = (Random.Range(_constants.NegativeDirection, _constants.PositiveDirection));
        _vertical = (Random.Range(_constants.NegativeDirection, _constants.PositiveDirection));
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
        if (collision.gameObject.CompareTag("BoundaryNorth"))
        {
            _rb.MovePosition(new Vector3(_rb.position.x, -_constants.BoundaryHeight + _boundaryWrapDistance, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundaryEast"))
        {
            _rb.MovePosition(new Vector3(_constants.BoundaryWidth - _boundaryWrapDistance, _rb.position.y, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundarySouth"))
        {
            _rb.MovePosition(new Vector3(_rb.position.x, _constants.BoundaryHeight - _boundaryWrapDistance, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundaryWest"))
        {
            _rb.MovePosition(new Vector3(-_constants.BoundaryWidth + _boundaryWrapDistance, _rb.position.y, _rb.position.z));
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            _horizontal = -_horizontal;
            _vertical = -_vertical;

            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            RecalculateDirection();
            
            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }
    }
}
