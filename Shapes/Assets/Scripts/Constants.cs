using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    public float BoundaryWidth { get; private set; }

    public float BoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        var boundaryEast = GameObject.FindGameObjectWithTag("BoundaryEast");
        BoundaryWidth = boundaryEast == null ? 0.0f : boundaryEast.transform.position.x;

        var boundaryNorth = GameObject.FindGameObjectWithTag("BoundaryNorth");
        BoundaryHeight = boundaryNorth == null ? 0.0f : boundaryNorth.transform.position.y;

        GameWidth = BoundaryWidth * 2;
        GameHeight = BoundaryHeight * 2;
    }
}
