using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private GameObject _boundary;

    public float BoundaryWidth { get; private set; }

    public float BoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        _boundary = GameObject.FindWithTag(Tags.Boundary);
        if (_boundary != null)
        {
            BoundaryWidth = _boundary.transform.GetChild(1).gameObject.transform.position.x;
            BoundaryHeight = _boundary.transform.GetChild(0).gameObject.transform.position.y;
        }

        GameWidth = BoundaryWidth * 2;
        GameHeight = BoundaryHeight * 2;
    }
}
