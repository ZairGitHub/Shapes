using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;
    private Rigidbody _rb;

    private Vector3 _direction;

    private float _speed;
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
    }

    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        _speed = _constants.BoundaryWidth;

        RecalculateDirection();
    }

    private void RecalculateDirection()
    {
        _horizontal = Random.Range(-1.0f, 1.0f);
        _vertical = Random.Range(-1.0f, 1.0f);
        
        RedirectDirectionVector();
    }

    private void RedirectDirectionVector()
    {
        _direction = new Vector3(_horizontal, _vertical, 0.0f).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity =
            _gameController.IsRunning ? _direction * _speed : Vector3.zero;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Boundary"))
        {
            switch (collision.gameObject.tag)
            {
                case "BoundaryEast":
                case "BoundaryWest":
                    _horizontal = -_horizontal;
                    break;
                case "BoundaryNorth":
                case "BoundarySouth":
                    _vertical = -_vertical;
                    break;
            }
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            _horizontal = -_horizontal;
            _vertical = -_vertical;

            GiveCollisionBonus(collision.gameObject);
        }
        
        Vector3 direction = new Vector3(_horizontal, _vertical, 0.0f);
        if (direction != _direction)
        {
            RedirectDirectionVector();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
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
