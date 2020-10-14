using UnityEngine;

public class Constants : MonoBehaviour
{
    public float NegativeDirection { get; } = -1.0f;
    public float PositiveDirection { get; } = 1.0f;

    public float BoundaryWidth { get; private set; }
    public float BoundaryHeight { get; private set; }

    private void Awake()
    {
        BoundaryWidth = (GameObject.FindGameObjectWithTag("BoundaryWest").transform.position.x
            - GameObject.FindGameObjectWithTag("BoundaryEast").transform.position.x) / 2.0f;
        BoundaryHeight = (GameObject.FindGameObjectWithTag("BoundaryNorth").transform.position.y
            - GameObject.FindGameObjectWithTag("BoundarySouth").transform.position.y) / 2.0f;
    }
}
