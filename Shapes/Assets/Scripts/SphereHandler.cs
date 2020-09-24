using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    // public for testing, otherwise private
    public float Speed;

    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;

    private Rigidbody _rb;
    private Vector3 _direction;

    // public for testing, otherwise private
    public float Horizontal;
    public float Vertical;

    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        RecalculateDirection();
        Speed = _constants.BoundaryWidth;
    }

    private void RecalculateDirection()
    {
        Horizontal = (Random.Range(-1.0f, 1.0f));
        Vertical = (Random.Range(-1.0f, 1.0f));
    }

    private void FixedUpdate()
    {
        if (_gameController.IsRunning)
        {
            _direction = new Vector3(Horizontal, Vertical, 0.0f).normalized;
            _rb.velocity = _direction * Speed;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoundaryEast") || collision.gameObject.CompareTag("BoundaryWest"))
        {
            Horizontal = -Horizontal;
        }

        else if (collision.gameObject.CompareTag("BoundaryNorth") || collision.gameObject.CompareTag("BoundarySouth"))
        {
            Vertical = -Vertical;
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            Horizontal = -Horizontal;
            Vertical = -Vertical;

            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
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
