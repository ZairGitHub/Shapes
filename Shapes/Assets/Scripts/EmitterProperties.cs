using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private const float _negative = -1.0f;
    private const float _positive = 1.0f;

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
            xDirection = _positive;
        }
        else if (name.Contains("Right"))
        {
            xDirection = _negative;
        }
        else
        {
            xDirection = Random.Range(_negative, _positive);
        }
        return xDirection;
    }

    public float GetYDirection()
    {
        float yDirection;

        if (name.Contains("Top"))
        {
            yDirection = _negative;
        }
        else if (name.Contains("Bottom"))
        {
            yDirection = _positive;
        }
        else
        {
            yDirection = Random.Range(_negative, _positive);
        }
        return yDirection;
    }

    public Vector3 GetPosition() => new Vector3(SetXPosition(), SetYPosition(), 0.0f);

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
