using UnityEngine;

public class Constants : MonoBehaviour
{
    private float boundaryWidth;
    private float boundaryHeight;

    private void Awake()
    {
        boundaryWidth = 20.0f;
        boundaryHeight = 10.0f;
    }

    public float GetBoundaryWidth()
    {
        return boundaryWidth;
    }

    public float GetBoundaryHeight()
    {
        return boundaryHeight;
    }
}
