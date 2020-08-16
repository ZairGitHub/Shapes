using UnityEngine;
using UnityEngine.Assertions.Must;

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

        switch (name)
        {
            case string a when a.Contains("TopLeft"):
                xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                zPosition = constants.GetBoundaryHeight() - boundaryOffset;
                break;
            case string a when a.Contains("TopMiddle"):
                xPosition = 0.0f;
                zPosition = constants.GetBoundaryHeight() - boundaryOffset;
                break;
            case string a when a.Contains("TopRight"):
                xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                zPosition = constants.GetBoundaryHeight() - boundaryOffset;
                break;
            case string a when a.Contains("MiddleLeft"):
                xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                zPosition = 0.0f;
                break;
            case string a when a.Contains("MiddleRight"):
                xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                zPosition = 0.0f;
                break;
            case string a when a.Contains("BottomLeft"):
                xPosition = -constants.GetBoundaryWidth() + boundaryOffset;
                zPosition = -constants.GetBoundaryHeight() + boundaryOffset;
                break;
            case string a when a.Contains("BottomMiddle"):
                xPosition = 0.0f;
                zPosition = -constants.GetBoundaryHeight() + boundaryOffset;
                break;
            case string a when a.Contains("BottomRight"):
                xPosition = constants.GetBoundaryWidth() - boundaryOffset;
                zPosition = -constants.GetBoundaryHeight() + boundaryOffset;
                break;
        }
    }

    public Vector3 SetPosition()
    {
        return new Vector3(xPosition, 0.0f, zPosition);
    }
}
