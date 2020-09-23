using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    public float speed;

    private Constants constants;
    private GameController gameController;
    private ScoreController scoreController;

    private Rigidbody rb;
    private Vector3 direction;

    // public for testing purposes
    public float horizontal;
    public float vertical;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;
        rb.useGravity = false;

        RecalculateDirection();
        speed = constants.BoundaryWidth;
    }

    private void RecalculateDirection()
    {
        horizontal = (Random.Range(-1.0f, 1.0f));
        vertical = (Random.Range(-1.0f, 1.0f));
    }

    private void FixedUpdate()
    {
        if (gameController.IsRunning)
        {
            direction = new Vector3(horizontal, vertical, 0.0f).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoundaryEast") || collision.gameObject.CompareTag("BoundaryWest"))
        {
            horizontal = -horizontal;
        }

        else if (collision.gameObject.CompareTag("BoundaryNorth") || collision.gameObject.CompareTag("BoundarySouth"))
        {
            vertical = -vertical;
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            horizontal = -horizontal;
            vertical = -vertical;

            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                scoreController.GiveCollisionBonus();
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
                scoreController.GiveCollisionBonus();
            }
        }
    }
}
