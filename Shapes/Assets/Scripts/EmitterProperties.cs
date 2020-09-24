using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private Constants _constants;

    private int _xDirection;
    private int _yDirection;

    private float _boundaryOffset;
    private float _xPosition;
    private float _yPosition;

    private void Start()
    {
        _constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        _boundaryOffset = GetComponent<Renderer>().bounds.size.x * 2;
    }

    public int SetAndGetXDirection()
    {
        if (name.Contains("Left"))
        {
            _xDirection = 1;
        }
        else if (name.Contains("Right"))
        {
            _xDirection = -1;
        }
        else
        {
            _xDirection = Random.Range(-1, 2);
        }
        return _xDirection;
    }

    public int SetAndGetYDirection()
    {
        if (name.Contains("Top"))
        {
            _yDirection = -1;
        }
        else if (name.Contains("Bottom"))
        {
            _yDirection = 1;
        }
        else
        {
            _yDirection = Random.Range(-1, 2);
        }
        return _yDirection;
    }

    private float SetXPosition()
    {
        if (name.Contains("Left"))
        {
            _xPosition = -_constants.BoundaryWidth + _boundaryOffset;
        }
        else if (name.Contains("Right"))
        {
            _xPosition = _constants.BoundaryWidth - _boundaryOffset;
        }
        return _xPosition;
    }

    private float SetYPosition()
    {
        if (name.Contains("Top"))
        {
            _yPosition = _constants.BoundaryHeight - _boundaryOffset;
        }
        else if (name.Contains("Bottom"))
        {
            _yPosition = -_constants.BoundaryHeight + _boundaryOffset;
        }
        return _yPosition;
    }

    public Vector3 SetAndGetPosition()
    {
        return new Vector3(SetXPosition(), SetYPosition(), 0.0f);
    }
}
