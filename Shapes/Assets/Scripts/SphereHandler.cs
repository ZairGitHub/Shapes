using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private float _speed;
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private IConstants _constants;
    private IGameController _gameController;
    private Rigidbody _rb;
    private ScoreController _scoreController;

    private void Awake()
    {
        _rb = (Rigidbody)NullChecker.TryGet(gameObject, GetComponent<Rigidbody>());
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
    }

    private void Start()
    {
        _constants = (Constants)NullChecker.TryGet<Constants>(gameObject,
                GameObject.FindWithTag("Constants").GetComponent<Constants>());

        _gameController = (GameController)NullChecker.TryGet<GameController>(gameObject,
                GameObject.FindWithTag("GameController").GetComponent<GameController>());

        _scoreController = _gameController.ScoreController;
    }

    public bool HasSpeed() => _speed > 0.0f;

    public void SetDirection()
    {
        RecalculateDirection();

        _speed = _constants.BoundaryWidth;
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
                case "BoundaryNorth":
                case "BoundarySouth":
                    _vertical = -_vertical;
                    break;
                case "BoundaryEast":
                case "BoundaryWest":
                    _horizontal = -_horizontal;
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
