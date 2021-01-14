using UnityEngine;

public class PlayerSpawner
{
    private const int maxPlayers = 4;

    private Vector3 _topLeftSpawn;
    private Vector3 _topRightSpawn;
    private Vector3 _bottomLeftSpawn;
    private Vector3 _bottomRightSpawn;
    
    public PlayerSpawner(Constants constants)
    {
        float spawnWidth = constants.BoundaryWidth / 2.0f;
        float spawnHeight = constants.BoundaryHeight / 2.0f;

        _topLeftSpawn = new Vector3(-spawnWidth, spawnHeight, 0.0f);
        _topRightSpawn = new Vector3(spawnWidth, spawnHeight, 0.0f);
        _bottomLeftSpawn = new Vector3(-spawnWidth, -spawnHeight, 0.0f);
        _bottomRightSpawn = new Vector3(spawnWidth, -spawnHeight, 0.0f);
    }

    //Convert to private after removing Debug command from PlayerController.cs
    public void SetSpawnPosition(Rigidbody rb)
    {
        // Currently randomised until multiplayer is implemented
        int RNG = Random.Range(1, maxPlayers + 1);
        switch (RNG)
        {
            case 1:
                rb.MovePosition(_topLeftSpawn);
                break;
            case 2:
                rb.MovePosition(_topRightSpawn);
                break;
            case 3:
                rb.MovePosition(_bottomLeftSpawn);
                break;
            case 4:
                rb.MovePosition(_bottomRightSpawn);
                break;
        }
        rb.velocity = Vector3.zero;
    }
}
