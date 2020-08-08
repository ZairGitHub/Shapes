using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Vector3 movement;

    private float horizontal;
    private float vertical;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        rb.MovePosition((Vector3.up) + new Vector3(-18,0,-8));

        horizontal = 1.0f;
        vertical = 1.0f;

        speed = 20.0f;
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horizontal, 0.0f, vertical);
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoundaryNorth"))
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, -8.0f));
        }

        if (collision.gameObject.CompareTag("BoundaryEast"))
        {
            rb.MovePosition(new Vector3(18.0f, rb.position.y, rb.position.z));
        }
        
        if (collision.gameObject.CompareTag("BoundarySouth"))
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 8.0f));
        }
        
        if (collision.gameObject.CompareTag("BoundaryWest"))
        {
            rb.MovePosition(new Vector3(-18.0f, rb.position.y, rb.position.z));
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            horizontal = -horizontal;
            vertical = -vertical;
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            // bounce in random direction
        }
    }
}
