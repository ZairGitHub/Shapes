using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private const int maxPlayers = 4;

    private Constants _constants;

    private Rigidbody _rb;

    private Vector3 _topLeftSpawn;
    private Vector3 _topRightSpawn;
    private Vector3 _bottomLeftSpawn;
    private Vector3 _bottomRightSpawn;

    private void Awake()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();

        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float spawnWidth = _constants.BoundaryWidth / 2.0f;
        float spawnHeight = _constants.BoundaryHeight / 2.0f;

        _topLeftSpawn = new Vector3(-spawnWidth, spawnHeight, 0.0f);
        _topRightSpawn = new Vector3(spawnWidth, spawnHeight, 0.0f);
        _bottomLeftSpawn = new Vector3(-spawnWidth, -spawnHeight, 0.0f);
        _bottomRightSpawn = new Vector3(spawnWidth, -spawnHeight, 0.0f);

        SetSpawnPosition();
    }

    public void SetSpawnPosition()
    {
        // Currently randomised until multiplayer is implemented
        int RNG = Random.Range(1, maxPlayers + 1);
        switch (RNG)
        {
            case 1:
                _rb.MovePosition(_topLeftSpawn);
                break;
            case 2:
                _rb.MovePosition(_topRightSpawn);
                break;
            case 3:
                _rb.MovePosition(_bottomLeftSpawn);
                break;
            case 4:
                _rb.MovePosition(_bottomRightSpawn);
                break;
        }
        _rb.velocity = Vector3.zero;
    }
}
