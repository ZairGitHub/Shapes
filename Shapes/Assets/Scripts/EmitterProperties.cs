using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private const float _collisionScale = 2.0f;
    private const float _negativeOne = -1.0f;
    private const float _positiveOne = 1.0f;

    private float _boundaryOffset;

    private Constants _constants;

    private void Awake() => name = name.ToLower();
    
    private void Start()
    {
        _boundaryOffset = GameObject.FindGameObjectWithTag("Cube")
            .GetComponent<Collider>().bounds.size.x * _collisionScale;

        _constants = GameObject.FindGameObjectWithTag("Constants")
            .GetComponent<Constants>();
    }

    public float GetXDirection()
    {
        float xDirection;
        if (name.Contains("left"))
        {
            xDirection = _positiveOne;
        }
        else if (name.Contains("right"))
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
        if (name.Contains("bottom"))
        {
            yDirection = _positiveOne;
        }
        else if (name.Contains("top"))
        {
            yDirection = _negativeOne;
        }
        else
        {
            yDirection = Random.Range(_negativeOne, _positiveOne);
        }
        return yDirection;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(SetXPosition(), SetYPosition(), 0.0f);
    }

    private float SetXPosition()
    {
        float xPosition;
        if (name.Contains("left"))
        {
            xPosition = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (name.Contains("right"))
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
        if (name.Contains("bottom"))
        {
            yPosition = -_constants.BoundaryHeight + _boundaryOffset;
        }
        else if (name.Contains("top"))
        {
            yPosition = _constants.BoundaryHeight - _boundaryOffset;
        }
        else
        {
            yPosition = 0.0f;
        }
        return yPosition;
    }
}
