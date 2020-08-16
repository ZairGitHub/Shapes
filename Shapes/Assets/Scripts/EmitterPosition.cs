using UnityEngine;

public class EmitterPosition : MonoBehaviour
{
    private Constants constants;

    private float boundaryOffset;
    private float xPosition;
    private float zPosition;

    private void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
        boundaryOffset = GetComponent<Renderer>().bounds.size.x * 2;
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
