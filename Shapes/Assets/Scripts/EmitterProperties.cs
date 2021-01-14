using UnityEngine;

public class EmitterProperties
{
    private const float _negativeOne = -1.0f;
    private const float _positiveOne = 1.0f;
    private const float _collisionScale = 2.0f;

    private float _boundaryOffset;

    private IConstants _constants;

    private GameObject _cube;
    private Transform _transform;

    public EmitterProperties(IConstants constants, GameObject cube)
    {
        _constants = constants;
        _boundaryOffset = cube.GetComponent<Collider>().bounds.size.x * _collisionScale;
    }

    public Vector3 SetPosition(float x, float y)
    {
        return new Vector3(SetXPosition(x), SetYPosition(y), 0.0f);
    }

    private float SetXPosition(float x)
    {
        float xPosition;
        if (x < 0.0f)
        {
            xPosition = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (x > 0.0f)
        {
            xPosition = _constants.BoundaryWidth - _boundaryOffset;
        }
        else
        {
            xPosition = 0.0f;
        }
        return xPosition;
    }

    private float SetYPosition(float y)
    {
        float yPosition;
        if (y < 0.0f)
        {
            yPosition = -_constants.BoundaryHeight + _boundaryOffset;
        }
        else if (y > 0.0f)
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
        if (_transform.position.x < 0.0f)
        {
            xDirection = _positiveOne;
        }
        else if (_transform.position.x > 0.0f)
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
        if (_transform.position.y < 0.0f)
        {
            yDirection = _positiveOne;
        }
        else if (_transform.position.y > 0.0f)
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
