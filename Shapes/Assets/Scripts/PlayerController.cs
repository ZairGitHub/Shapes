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

        spawnWidth = constants.GetBoundaryWidth() / 2;
        spawnHeight = constants.GetBoundaryHeight() / 2;

        // Different spawn positions for different players
        topLeftSpawn = new Vector3(-spawnWidth, 0.0f, spawnHeight);
        topRightSpawn = new Vector3(spawnWidth, 0.0f, spawnHeight);
        bottomLeftSpawn = new Vector3(-spawnWidth, 0.0f, -spawnHeight);
        bottomRightSpawn = new Vector3(spawnWidth, 0.0f, -spawnHeight);

        Reset();
        speed = constants.GetBoundaryWidth();
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
        int RNG = Random.Range(1, 5);
        switch (RNG)
        {
            case 1:
                rb.MovePosition(Vector3.up + topLeftSpawn);
                break;
            case 2:
                rb.MovePosition(Vector3.up + topRightSpawn);
                break;
            case 3:
                rb.MovePosition(Vector3.up + bottomLeftSpawn);
                break;
            case 4:
                rb.MovePosition(Vector3.up + bottomRightSpawn);
                break;
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
