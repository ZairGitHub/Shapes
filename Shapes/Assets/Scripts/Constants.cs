using UnityEngine;

public class Constants : MonoBehaviour
{
    public float BoundaryWidth { get; private set; }
    public float BoundaryHeight { get; private set; }

    private void Awake()
    {
        BoundaryWidth = GameObject.FindGameObjectWithTag("BoundaryEast")
            .transform.position.x;

        BoundaryHeight =
            (GameObject.FindGameObjectWithTag("BoundaryNorth").transform.position.y
            - GameObject.FindGameObjectWithTag("BoundarySouth").transform.position.y)
            / 2.0f;
    }
}
