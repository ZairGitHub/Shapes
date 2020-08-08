using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHandler : MonoBehaviour
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
        rb.MovePosition(Vector3.up);

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
        if (collision.gameObject.CompareTag("BoundaryEast") || collision.gameObject.CompareTag("BoundaryWest"))
        {
            horizontal = -horizontal;
        }

        if (collision.gameObject.CompareTag("BoundaryNorth") || collision.gameObject.CompareTag("BoundarySouth"))
        {
            vertical = -vertical;
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            // bounce in random direction
        }

        if (collision.gameObject.CompareTag("Sphere"))
        {
            horizontal = -horizontal;
            vertical = -vertical;
        }
    }
}
