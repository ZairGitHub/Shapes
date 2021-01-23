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
            .TryFind<Constants>(Tags.Constants, gameObject);

        _gameController = (IGameController)NullChecker
            .TryFind<GameController>(Tags.GameController, gameObject);

        _scoreController = _gameController.ScoreController;
    }

    public void RunTestingConstructor(IConstants constants)
    {
        _constants = constants;
    }

    public void SetDirection()
    {
        RecalculateDirection();

        Speed = _constants.HalfBoundaryWidth;
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
            _gameController.IsRunning ? _direction * Speed : Vector3.zero;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains(Tags.Boundary))
        {
            switch (collision.gameObject.tag)
            {
                case nameof(Tags.BoundaryNorth):
                case nameof(Tags.BoundarySouth):
                    _vertical = -_vertical;
                    break;
                case nameof(Tags.BoundaryEast):
                case nameof(Tags.BoundaryWest):
                    _horizontal = -_horizontal;
                    break;
            }
        }

        if (collision.gameObject.CompareTag(Tags.Sphere))
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
        if (collision.gameObject.CompareTag(Tags.Cube))
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
