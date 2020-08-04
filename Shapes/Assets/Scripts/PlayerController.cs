using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rb;
    private Vector3 movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        Reset();
    }

    private void Reset()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        rb.MovePosition(Vector3.up);
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (rb.position.x < -20)
        {
            rb.MovePosition(new Vector3(-20.0f, rb.position.y, rb.position.z));
        }
        else if (rb.position.x > 20)
        {
            rb.MovePosition(new Vector3(20.0f, rb.position.y, rb.position.z));
        }

        if (rb.position.z < -10)
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, -10.0f));
        }
        else if (rb.position.z > 10)
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 10.0f));
        }

        movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        rb.velocity = movement * speed + new Vector3(0.0f, rb.velocity.y, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // Create other collidable objects

        if (collision.gameObject.CompareTag("Boundary"))
        {
            //Reset();
        }
    }
}
