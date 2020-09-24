﻿using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    // public for testing, otherwise private
    public float Speed;

    private Constants _constants;
    private GameController _gameController;
    private ScoreController _scoreController;

    private Rigidbody _rb;
    private Vector3 _direction;

    // public for testing, otherwise private
    public float Horizontal;
    public float Vertical;

    private float _boundaryWrapDistance;
    
    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;

        Speed = _constants.BoundaryWidth / 4;
        _boundaryWrapDistance = GetComponent<Collider>().bounds.size.x * 1.1f;
    }

    public void SetDirection(int x, int y)
    {
        Horizontal = (x > 0) ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);
        Vertical = (y > 0) ? Random.Range(0.0f, 1.0f) : Random.Range(-1.0f, 0.0f);
    }

    private void RecalculateDirection()
    {
        Horizontal = (Random.Range(-1.0f, 1.0f));
        Vertical = (Random.Range(-1.0f, 1.0f));
    }

    private void FixedUpdate()
    {
        if (_gameController.IsRunning)
        {
            _direction = new Vector3(Horizontal, Vertical, 0.0f).normalized;
            _rb.velocity = _direction * Speed;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoundaryNorth"))
        {
            _rb.MovePosition(new Vector3(_rb.position.x, -_constants.BoundaryHeight + _boundaryWrapDistance, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundaryEast"))
        {
            _rb.MovePosition(new Vector3(_constants.BoundaryWidth - _boundaryWrapDistance, _rb.position.y, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundarySouth"))
        {
            _rb.MovePosition(new Vector3(_rb.position.x, _constants.BoundaryHeight - _boundaryWrapDistance, _rb.position.z));
        }

        else if (collision.gameObject.CompareTag("BoundaryWest"))
        {
            _rb.MovePosition(new Vector3(-_constants.BoundaryWidth + _boundaryWrapDistance, _rb.position.y, _rb.position.z));
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            Horizontal = -Horizontal;
            Vertical = -Vertical;

            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            RecalculateDirection();
            
            if (collision.gameObject.GetInstanceID() > GetInstanceID())
            {
                _scoreController.GiveCollisionBonus();
            }
        }
    }
}
