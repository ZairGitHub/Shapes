using UnityEngine;

public class Constants : MonoBehaviour
{
    public float BoundaryHeight { get; private set; }
    public float BoundaryWidth { get; private set; }

    private void Awake()
    {
        BoundaryHeight = (GameObject.FindGameObjectWithTag("BoundaryNorth").transform.position.y
            - GameObject.FindGameObjectWithTag("BoundarySouth").transform.position.y) / 2.0f;

        BoundaryWidth = (GameObject.FindGameObjectWithTag("BoundaryWest").transform.position.x
            - GameObject.FindGameObjectWithTag("BoundaryEast").transform.position.x) / 2.0f;
    }
}
