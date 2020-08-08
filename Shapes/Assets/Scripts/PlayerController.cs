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
        SetPosition();
    }

    private void SetPosition()
    {
        // Different spawn positions for different players (GameController)
        Vector3 topLeft = new Vector3(-10.0f, 0.0f, 5.0f);
        Vector3 topRight = new Vector3(10.0f, 0.0f, 5.0f);
        Vector3 bottomLeft = new Vector3(-10.0f, 0.0f, -5.0f);
        Vector3 bottomRight = new Vector3(10.0f, 0.0f, -5.0f);

        rb.MovePosition(Vector3.up + topLeft);
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Sphere"))
        {
            //Reset();
            gameObject.SetActive(false);
        }
    }
}
