using UnityEngine;

public class Constants : MonoBehaviour
{
    public float BoundaryWidth { get; private set; }
    public float BoundaryHeight { get; private set; }
    public float GameWidth { get; private set; }
    public float GameHeight { get; private set; }

    private enum Direction
    {
        North,
        South,
        East,
        West
    }

    private void Awake()
    {
        BoundaryWidth = GameObject.FindGameObjectWithTag("BoundaryEast")
            .transform.position.x;

        BoundaryHeight =
            GameObject.FindGameObjectWithTag("BoundaryNorth")
            .transform.position.y;

        GameWidth = BoundaryWidth * 2;
        GameHeight = BoundaryHeight * 2;
    }
}
