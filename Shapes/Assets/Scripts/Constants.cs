using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private Vector3 _boundaryNorth;
    private Vector3 _boundaryEast;
    private Vector3 _boundarySouth;
    private Vector3 _boundaryWest;
    private GameObject _boundary;

    public float BoundaryWidth { get; private set; }

    public float BoundaryHeight { get; private set; }

    public float HalfBoundaryWidth { get; private set; }

    public float HalfBoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        _boundary = GameObject.FindWithTag(Tags.BoundaryGame);
        if (_boundary != null)
        {
            _boundaryNorth = _boundary.transform.GetChild(0).position;
            _boundaryEast = _boundary.transform.GetChild(1).position;
            _boundarySouth = _boundary.transform.GetChild(2).position;
            _boundaryWest = _boundary.transform.GetChild(3).position;

            BoundaryWidth = _boundaryEast.x - _boundaryWest.x;
            BoundaryHeight = _boundaryNorth.y - _boundarySouth.y;
        }

        // 4.3
        HalfBoundaryWidth = BoundaryWidth / 2.0f;
        HalfBoundaryHeight = BoundaryHeight / 2.0f;

        // 16:9
        GameWidth = BoundaryWidth * 2.0f;
        GameHeight = BoundaryHeight * 2.0f;
    }
}
