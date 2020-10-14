using UnityEngine;

public class EmitterProperties : MonoBehaviour
{    
    private Constants _constants;

    private float _boundaryOffset;

    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _boundaryOffset = GetComponent<Renderer>().bounds.size.x * 2.0f;
    }

    public float GetXDirection()
    {
        float xDirection;

        if (name.Contains("Left"))
        {
            xDirection = _constants.PositiveDirection;
        }
        else if (name.Contains("Right"))
        {
            xDirection = _constants.NegativeDirection;
        }
        else
        {
            xDirection = Random.Range(_constants.NegativeDirection, _constants.PositiveDirection);
        }
        return xDirection;
    }

    public float GetYDirection()
    {
        float yDirection;

        if (name.Contains("Top"))
        {
            yDirection = _constants.NegativeDirection;
        }
        else if (name.Contains("Bottom"))
        {
            yDirection = _constants.PositiveDirection;
        }
        else
        {
            yDirection = Random.Range(_constants.NegativeDirection, _constants.PositiveDirection);
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

        if (name.Contains("Left"))
        {
            xPosition = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (name.Contains("Right"))
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

        if (name.Contains("Top"))
        {
            yPosition = _constants.BoundaryHeight - _boundaryOffset;
        }
        else if (name.Contains("Bottom"))
        {
            yPosition = -_constants.BoundaryHeight + _boundaryOffset;
        }
        else
        {
            yPosition = 0.0f;
        }
        return yPosition;
    }
}
