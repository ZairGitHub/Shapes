using UnityEngine;

public class EmitterProperties
{
    private readonly float _boundaryOffset;
    private readonly IConstants _constants;

    public EmitterProperties(IConstants constants, float boundaryOffset = 0.0f)
    {
        _constants = constants;
        _boundaryOffset = boundaryOffset;
    }

    public Vector3 SetPosition(Vector3 position)
    {
        return new Vector3(SetXPosition(position.x), SetYPosition(position.y), 0.0f);
    }

    private float SetXPosition(float x)
    {
        if (x < 0.0f)
        {
            x = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (x > 0.0f)
        {
            x = _constants.BoundaryWidth - _boundaryOffset;
        }
        return x;
    }

    private float SetYPosition(float y)
    {
        if (y < 0.0f)
        {
            y = -_constants.BoundaryHeight + _boundaryOffset;
        }
        else if (y > 0.0f)
        {
            y = _constants.BoundaryHeight - _boundaryOffset;
        }
        return y;
    }

    public float GetDirection(float axis)
    {
        if (axis < 0.0f)
        {
            axis = 1.0f;
        }
        else if (axis > 0.0f)
        {
            axis = -1.0f;
        }
        else
        {
            axis = Random.Range(-1.0f, 1.0f);
        }
        return axis;
    }
}
