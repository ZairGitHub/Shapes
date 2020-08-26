using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Constants constants;
    private GameController gameController;

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
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;
        rb.useGravity = false;

        spawnWidth = constants.GetBoundaryWidth() / 2;
        spawnHeight = constants.GetBoundaryHeight() / 2;

        // Different spawn positions for different players
        topLeftSpawn = new Vector3(-spawnWidth, spawnHeight, 0.0f);
        topRightSpawn = new Vector3(spawnWidth, spawnHeight, 0.0f);
        bottomLeftSpawn = new Vector3(-spawnWidth, -spawnHeight, 0.0f);
        bottomRightSpawn = new Vector3(spawnWidth, -spawnHeight, 0.0f);

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
                rb.MovePosition(topLeftSpawn);
                break;
            case 2:
                rb.MovePosition(topRightSpawn);
                break;
            case 3:
                rb.MovePosition(bottomLeftSpawn);
                break;
            case 4:
                rb.MovePosition(bottomRightSpawn);
                break;
        }
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalAxis, verticalAxis, 0.0f);
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Sphere"))
        {
            //Reset();
            gameController.Reset();
            gameObject.SetActive(false);
        }
    }
}
