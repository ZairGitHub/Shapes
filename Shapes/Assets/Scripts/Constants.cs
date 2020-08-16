using UnityEngine;

public class Constants : MonoBehaviour
{
    private float boundaryWidth;
    private float boundaryHeight;

    private void Awake()
    {        
        boundaryWidth = (GameObject.FindGameObjectWithTag("BoundaryWest").transform.position.x
            - GameObject.FindGameObjectWithTag("BoundaryEast").transform.position.x) / 2;
        boundaryHeight = (GameObject.FindGameObjectWithTag("BoundaryNorth").transform.position.z
            - GameObject.FindGameObjectWithTag("BoundarySouth").transform.position.z) / 2;
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
