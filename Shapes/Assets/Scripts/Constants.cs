using UnityEngine;

public class Constants : MonoBehaviour, IConstants
{
    private Vector3 _boundaryNorth;
    private Vector3 _boundaryEast;
    private Vector3 _boundarySouth;
    private Vector3 _boundaryWest;
    private GameObject _boundary;

    public float HalfBoundaryWidth { get; private set; }

    public float HalfBoundaryHeight { get; private set; }

    public float FullBoundaryWidth { get; private set; }

    public float FullBoundaryHeight { get; private set; }

    public float GameWidth { get; private set; }

    public float GameHeight { get; private set; }

    private void Awake()
    {
        _boundary = GameObject.FindWithTag(Tags.Boundary);
        if (_boundary != null)
        {
            _boundaryNorth = _boundary.transform.GetChild(0).position;
            _boundaryEast = _boundary.transform.GetChild(1).position;
            _boundarySouth = _boundary.transform.GetChild(2).position;
            _boundaryWest = _boundary.transform.GetChild(3).position;

            FullBoundaryWidth = _boundaryEast.x - _boundaryWest.x;
            FullBoundaryHeight = _boundaryNorth.y - _boundarySouth.y;

            HalfBoundaryWidth = FullBoundaryWidth / 2.0f;
            HalfBoundaryHeight = FullBoundaryHeight / 2.0f;

            Debug.Log($"FullWidth: {FullBoundaryWidth}, FullHeight: {FullBoundaryHeight} | " +
                $"BoundaryWidth {HalfBoundaryWidth}, BoundaryHeight {HalfBoundaryHeight}");
        }

        // 16:9
        GameWidth = HalfBoundaryWidth * 2;
        GameHeight = HalfBoundaryHeight * 2;
    }
}
