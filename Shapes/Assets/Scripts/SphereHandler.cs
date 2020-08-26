using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    public float speed;

    private Constants constants;
    private ScoreController scoreController;

    private Rigidbody rb;
    private Vector3 direction;

    // public for testing purposes
    public float horizontal;
    public float vertical;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;
        rb.useGravity = false;

        RecalculateDirection();
        speed = constants.GetBoundaryWidth();
    }

    private void RecalculateDirection()
    {
        horizontal = (Random.Range(-1.0f, 1.0f));
        vertical = (Random.Range(-1.0f, 1.0f));
    }

    private void FixedUpdate()
    {
        direction = new Vector3(horizontal, vertical, 0.0f).normalized;
        rb.velocity = direction * speed;
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
                scoreController.GiveBounceBonus(collision.gameObject.tag);
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
                scoreController.GiveRedirectionBonus();
            }
        }
    }
}
