using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private const float _collisionScale = 2.0f;
    private const float _negativeOne = -1.0f;
    private const float _positiveOne = 1.0f;

    private float _boundaryOffset;

    private Constants _constants;
    
    private void Start()
    {
        _boundaryOffset = GameObject.FindGameObjectWithTag("Cube")
            .GetComponent<Collider>().bounds.size.x * _collisionScale;

        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();

        SetPosition();
    }

    private void SetPosition()
    {
        transform.position = new Vector3(SetXPosition(), SetYPosition(), 0.0f);
    }

    private float SetXPosition()
    {
        float xPosition;
        if (transform.position.x < 0)
        {
            xPosition = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (transform.position.x > 0)
        {
            xPosition = _constants.BoundaryWidth - _boundaryOffset;
        }
        else
        {
            xPosition = 0.0f;
        }
        return xPosition;
    }

    private float SetYPosition()
    {
        float yPosition;
        if (transform.position.y < 0)
        {
            yPosition = -_constants.BoundaryHeight + _boundaryOffset;
        }
        else if (transform.position.y > 0)
        {
            yPosition = _constants.BoundaryHeight - _boundaryOffset;
        }
        else
        {
            yPosition = 0.0f;
        }
        return yPosition;
    }

    public float GetXDirection()
    {
        float xDirection;
        if (transform.position.x < 0)
        {
            xDirection = _positiveOne;
        }
        else if (transform.position.x > 0)
        {
            xDirection = _negativeOne;
        }
        else
        {
            xDirection = Random.Range(_negativeOne, _positiveOne);
        }
        return xDirection;
    }

    public float GetYDirection()
    {
        float yDirection;
        if (transform.position.y < 0)
        {
            yDirection = _positiveOne;
        }
        else if (transform.position.y > 0)
        {
            yDirection = _negativeOne;
        }
        else
        {
            yDirection = Random.Range(_negativeOne, _positiveOne);
        }
        return yDirection;
    }
}
