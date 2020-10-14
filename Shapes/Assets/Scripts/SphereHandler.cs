using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private const float _negative = -1.0f;
    private const float _positive = 1.0f;

    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;

    private Rigidbody _rb;
    private Vector3 _direction;

    private float _speed;
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

        _speed = _constants.BoundaryWidth;

        RecalculateDirection();
    }

    private void RecalculateDirection()
    {
        _horizontal = (Random.Range(_negative, _positive));
        _vertical = (Random.Range(_negative, _positive));
        
        UpdateDirectionVector();
    }

    private void UpdateDirectionVector()
    {
        _direction = new Vector3(_horizontal, _vertical, 0.0f).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _gameController.IsRunning ? _direction * _speed : _rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = new Vector3(_horizontal, _vertical, 0.0f);
        
        if (collision.gameObject.CompareTag("BoundaryEast") || collision.gameObject.CompareTag("BoundaryWest"))
        {
            _horizontal = -_horizontal;
        }

        else if (collision.gameObject.CompareTag("BoundaryNorth") || collision.gameObject.CompareTag("BoundarySouth"))
        {
            _vertical = -_vertical;
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            _horizontal = -_horizontal;
            _vertical = -_vertical;

            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }

        if (direction != _direction)
        {
            UpdateDirectionVector();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            RecalculateDirection();
            
            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }
    }
}
