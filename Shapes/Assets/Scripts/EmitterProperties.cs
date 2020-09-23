using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private Constants constants;

    private int xDirection;
    private int yDirection;

    private float boundaryOffset;
    private float xPosition;
    private float yPosition;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        boundaryOffset = GetComponent<Renderer>().bounds.size.x * 2;
    }

    public int GetXDirection()
    {
        if (name.Contains("Left"))
        {
            xDirection = 1;
        }
        else if (name.Contains("Right"))
        {
            xDirection = -1;
        }
        else
        {
            xDirection = Random.Range(-1, 2);
        }
        return xDirection;
    }

    public int GetYDirection()
    {
        if (name.Contains("Top"))
        {
            yDirection = -1;
        }
        else if (name.Contains("Bottom"))
        {
            yDirection = 1;
        }
        else
        {
            yDirection = Random.Range(-1, 2);
        }
        return yDirection;
    }

    public Vector3 SetPosition()
    {
        switch (name)
        {
            case string name when name.Contains("Top"):
                yPosition = constants.BoundaryHeight - boundaryOffset;
                if (name.Contains("Left"))
                {
                    xPosition = -constants.BoundaryWidth + boundaryOffset;
                }
                else if (name.Contains("Right"))
                {
                    xPosition = constants.BoundaryWidth - boundaryOffset;
                }
                break;

            case string name when name.Contains("CentreLeft"):
                xPosition = -constants.BoundaryWidth + boundaryOffset;
                break;
            case string name when name.Contains("CentreRight"):
                xPosition = constants.BoundaryWidth - boundaryOffset;
                break;

            case string name when name.Contains("Bottom"):
                yPosition = -constants.BoundaryHeight + boundaryOffset;
                if (name.Contains("Left"))
                {
                    xPosition = -constants.BoundaryWidth + boundaryOffset;
                }
                else if (name.Contains("Right"))
                {
                    xPosition = constants.BoundaryWidth - boundaryOffset;
                }
                break;
        }
        return new Vector3(xPosition, yPosition, 0.0f);
    }
}
