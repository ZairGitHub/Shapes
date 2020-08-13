using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public float speed;

    private Constants constants;

    private Rigidbody rb;
    private Vector3 direction;

    // public for testing purposes
    public float horizontal;
    public float vertical;

    private float boundaryWrapDistance;
    
    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.freezeRotation = true;
        rb.useGravity = false;

        speed = constants.boundaryWidth / 2;
        boundaryWrapDistance = GetComponent<Collider>().bounds.size.x * 1.1f;
    }

    public void SetDirection(int x, int z)
    {
        horizontal = (x > 0) ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);
        vertical = (z > 0) ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);
    }

    private void RecalculateDirection()
    {
        horizontal = (Random.Range(-1.0f, 1.0f));
        vertical = (Random.Range(-1.0f, 1.0f));
    }

    private void FixedUpdate()
    {
        direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoundaryNorth"))
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, -constants.boundaryWidth + boundaryWrapDistance));
        }

        else if (collision.gameObject.CompareTag("BoundaryEast"))
        {
            rb.MovePosition(new Vector3(constants.boundaryHeight - boundaryWrapDistance, rb.position.y, rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundarySouth"))
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, constants.boundaryWidth - boundaryWrapDistance));
        }

        else if (collision.gameObject.CompareTag("BoundaryWest"))
        {
            rb.MovePosition(new Vector3(-constants.boundaryHeight + boundaryWrapDistance, rb.position.y, rb.position.z));
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            horizontal = -horizontal;
            vertical = -vertical;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            RecalculateDirection();
        }
    }
}
