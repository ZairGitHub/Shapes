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
            case string a when a.Contains("Top"):
                zPosition = constants.GetBoundaryHeight() - boundaryOffset;
                if (a.Contains("Left"))
                {
                    xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                }
                else if (a.Contains("Right"))
                {
                    xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                }
                break;

            case string a when a.Contains("MiddleLeft"):
                xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                break;
            case string a when a.Contains("MiddleRight"):
                xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                break;

            case string a when a.Contains("Bottom"):
                zPosition = -constants.GetBoundaryHeight() + boundaryOffset;
                if (a.Contains("Left"))
                {
                    xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                }
                else if (a.Contains("Right"))
                {
                    xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                }
                break;
        }
        return new Vector3(xPosition, 0.0f, zPosition);
    }
}
