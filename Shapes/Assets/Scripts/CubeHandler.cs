using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Vector3 movement;

    public float horizontal, vertical;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        RecalculateVelocity();
    }

    private void RecalculateVelocity()
    {
        // Possibly scale these values with current level
        horizontal = Random.Range(-1.0f, 1.0f);
        vertical = Random.Range(-1.0f, 1.0f);
        speed = 20.0f;
    }

    private void RecalculateVertical(float min, float max)
    {
        vertical = Random.Range(min, max);
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horizontal, 0.0f, vertical);
        rb.velocity = movement * speed + new Vector3(0.0f, rb.velocity.y, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            RecalculateVelocity();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (rb.position.x < -20 || rb.position.x > 20)
            {
                horizontal = -horizontal;
            }
            
            if (rb.position.z < -10 || rb.position.z > 10)
            {
                vertical = -vertical;
            }
        }
    }
}
