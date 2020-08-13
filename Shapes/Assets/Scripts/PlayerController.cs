using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Constants constants;

    private Rigidbody rb;
    private Vector3 movement;

    private float spawnHeight;
    private float spawnWidth;

    private Vector3 topLeftSpawn;
    private Vector3 topRightSpawn;
    private Vector3 bottomLeftSpawn;
    private Vector3 bottomRightSpawn;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        spawnHeight = constants.boundaryHeight / 2;
        spawnWidth = constants.boundaryWidth / 2;

        // Different spawn positions for different players
        topLeftSpawn = new Vector3(-spawnHeight, 0.0f, spawnWidth);
        topRightSpawn = new Vector3(spawnHeight, 0.0f, spawnWidth);
        bottomLeftSpawn = new Vector3(-spawnHeight, 0.0f, -spawnWidth);
        bottomRightSpawn = new Vector3(spawnHeight, 0.0f, -spawnWidth);

        Reset();
        speed = constants.boundaryWidth;
    }

    private void Reset()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        SetSpawnPosition();
    }

    private void SetSpawnPosition()
    {
        // Currently randomised until multiplayer is implemented
        int RNG = Random.Range(1, 101);
        if (RNG < 25)
        {
            rb.MovePosition(Vector3.up + topLeftSpawn);
        }
        else if (RNG < 50)
        {
            rb.MovePosition(Vector3.up + topRightSpawn);
        }
        else if (RNG < 75)
        {
            rb.MovePosition(Vector3.up + bottomLeftSpawn);
        }
        else
        {
            rb.MovePosition(Vector3.up + bottomRightSpawn);
        }

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
            Reset();
            //gameObject.SetActive(false);
        }
    }
}
