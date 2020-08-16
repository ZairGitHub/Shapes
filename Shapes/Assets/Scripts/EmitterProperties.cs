using UnityEngine;

public class EmitterProperties : MonoBehaviour
{
    private Constants constants;

    private int xDirection;
    private int zDirection;

    private float boundaryOffset;
    private float xPosition;
    private float zPosition;

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

    public int GetZDirection()
    {
        if (name.Contains("Top"))
        {
            zDirection = -1;
        }
        else if (name.Contains("Bottom"))
        {
            zDirection = 1;
        }
        else
        {
            zDirection = Random.Range(-1, 2);
        }
        return zDirection;
    }

    public Vector3 SetPosition()
    {
        switch (name)
        {
            case string name when name.Contains("Top"):
                zPosition = constants.GetBoundaryHeight() - boundaryOffset;
                if (name.Contains("Left"))
                {
                    xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                }
                else if (name.Contains("Right"))
                {
                    xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                }
                break;

            case string name when name.Contains("CentreLeft"):
                xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                break;
            case string name when name.Contains("CentreRight"):
                xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                break;

            case string name when name.Contains("Bottom"):
                zPosition = -constants.GetBoundaryHeight() + boundaryOffset;
                if (name.Contains("Left"))
                {
                    xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                }
                else if (name.Contains("Right"))
                {
                    xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                }
                break;
        }
        return new Vector3(xPosition, 0.0f, zPosition);
    }
}
