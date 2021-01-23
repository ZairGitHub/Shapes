using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private IConstants _constants;
    private IGameController _gameController;
    private Rigidbody _rb;
    private ScoreController _scoreController;

    public float Speed { get; private set; }

    private void Awake()
    {
        _rb = (Rigidbody)NullChecker.TryGet<Rigidbody>(gameObject);
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
    }

    private void Start()
    {
        _constants = (IConstants)NullChecker
            .TryFind<Constants>("Constants", gameObject);

        _gameController = (IGameController)NullChecker
            .TryFind<GameController>("GameController", gameObject);

        _scoreController = _gameController.ScoreController;
    }

    public void RunTestingConstructor(IConstants constants)
    {
        _constants = constants;
    }

    public void SetDirection()
    {
        RecalculateDirection();

        Speed = _constants.BoundaryWidth;
    }

    private void RecalculateDirection()
    {
        _horizontal = UnityEngine.Random.Range(-1.0f, 1.0f);
        _vertical = UnityEngine.Random.Range(-1.0f, 1.0f);

        RedirectDirectionVector();
    }

    private void RedirectDirectionVector()
    {
        _direction = new Vector3(_horizontal, _vertical, 0.0f).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity =
            _gameController.IsRunning ? _direction * Speed : Vector3.zero;
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
